using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;
using LendingCompany.BL.Services;
using LendingCompany.BL.Services.Interfaces;
using Moq;
using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LendingCompany.UnitTests
{
    public class LoanServiceTests
    {
        private readonly ILoanService _loanService;
        
        public LoanServiceTests()
        {
            var paymentServiceMock = new Mock<IPaymentService>();
            paymentServiceMock
                .Setup(x => x.CreatePayment(It.IsAny<double>(), It.IsAny<DateTime>(), It.IsAny<Guid>()))
                .ReturnsAsync((double baseAmount, DateTime finalPaymentDate, Guid loanId)
                    => new Payment(baseAmount, finalPaymentDate, loanId));

            var uowMock = new Mock<IUnitOfWork>();
            _loanService = new LoanService(paymentServiceMock.Object, uowMock.Object);
        }

        [Test]
        public async Task CalculatePaymentsWhenInterestIsZero()
        {
            var loan = new Loan(5, 0, 500);

            var result = await _loanService.CalculatePayments(loan);

            result.Should().HaveValue();
            result.Should().HaveNumberOfPayments(loan.NumberOfInstallments);
            result.Should().HaveAllPaymentsWithAmount(100);
        }

        [Test]
        public async Task CalculatePaymentsWhenInterestIsInteger()
        {
            var loan = new Loan(5, 10, 500);

            var result = await _loanService.CalculatePayments(loan);

            result.Should().HaveValue();
            result.Should().HaveNumberOfPayments(loan.NumberOfInstallments);
            result.Should().HaveLastPaymentWithAmount(110);
        }

        [Test]
        public async Task CalculatePaymentsWhenInterestIsNotInteger()
        {
            var loan = new Loan(3, 3, 500);

            var result = await _loanService.CalculatePayments(loan);

            result.Should().HaveValue();
            result.Should().HaveNumberOfPayments(loan.NumberOfInstallments);
            result.Should().HaveAllPaymentExceptLastWithAmount(171.66);
            result.Should().HaveLastPaymentWithAmount(171.68);
        }
    }
}
