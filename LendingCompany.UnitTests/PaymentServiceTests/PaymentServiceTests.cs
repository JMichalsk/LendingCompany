using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentAssertions;
using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;
using LendingCompany.BL.Services;
using LendingCompany.BL.Services.Interfaces;
using Moq;
using NUnit.Framework;

namespace LendingCompany.UnitTests.PaymentServiceTests
{
    public class PaymentServiceTests : PaymentServiceTestBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentServiceTests()
        {
            var paymentRepositoryMock = new Mock<IPaymentRepository>();
            paymentRepositoryMock.Setup(x =>
                    x.GetPaymentsWhere(It.IsAny<Expression<Func<Payment, bool>>>()))
                .Returns<Expression<Func<Payment, bool>>>(expression => Payments.Where(expression.Compile()).ToList());
            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.CompleteAsync())
                .Callback(() => SaveCount++);

            _paymentService = new PaymentService(paymentRepositoryMock.Object, uowMock.Object);
        }

        [Test]
        public async Task FoundPaymentWhenEqualAmountIsPaid()
        {
            var loanId = new Guid();
            CreatePayment(100, loanId);

            var change = await _paymentService.FoundPayment(loanId, 100);

            change.Should().Be(0);
            SaveCount.Should().Be(1);
            Payments.Should().HaveAllPaymentsPaid();
            Payments[0].Should().HavePaidAmount(100);
        }

        [Test]
        public async Task FoundPaymentFirstPaymentIsPaid()
        {
            var loanId = new Guid();
            CreatePayment(100, loanId, 0, true);
            CreatePayment(100, loanId, 1);

            var change = await _paymentService.FoundPayment(loanId, 100);

            change.Should().Be(0);
            SaveCount.Should().Be(1);
            Payments.Should().HaveAllPaymentsPaid();
            Payments[1].Should().HavePaidAmount(100);
        }

        [Test]
        public async Task PaymentPartiallyPaid()
        {
            var loanId = new Guid();
            CreatePayment(100, loanId);

            var change = await _paymentService.FoundPayment(loanId, 50);

            change.Should().Be(0);
            SaveCount.Should().Be(1);
            Payments[0].Should().HavePaidAmount(50);
            Payments[0].IsPaid.Should().BeFalse();
        }

        [Test]
        public async Task PaymentIsBiggerThanNeededToPayLoan()
        {
            var loanId = new Guid();
            CreatePayment(100, loanId);

            var change = await _paymentService.FoundPayment(loanId, 200);

            change.Should().Be(100);
            SaveCount.Should().Be(1);
            Payments[0].Should().HavePaidAmount(100);
            Payments[0].IsPaid.Should().BeTrue();
        }

        [Test]
        public async Task PaymentIsBiggerThanOneInstallmentCost()
        {
            var loanId = new Guid();
            CreatePayment(100, loanId);
            CreatePayment(100, loanId, 1);

            var change = await _paymentService.FoundPayment(loanId, 200);

            change.Should().Be(0);
            SaveCount.Should().Be(1);
            Payments.Should().HaveAllPaymentsPaid();
            Payments[0].PaidAmount.Should().Be(100);
            Payments[1].PaidAmount.Should().Be(100);

        }
    }
}
