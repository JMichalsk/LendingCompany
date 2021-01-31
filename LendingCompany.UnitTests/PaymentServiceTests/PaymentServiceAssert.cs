using System.Collections.Generic;
using FluentAssertions;
using LendingCompany.BL.Model;

namespace LendingCompany.UnitTests.PaymentServiceTests
{
    public class PaymentServiceAssert
    {
        private readonly List<Payment> _payments;
        private readonly Payment _payment;

        public PaymentServiceAssert(List<Payment> payments)
        {
            _payments = payments;
        }

        public PaymentServiceAssert(Payment payment)
        {
            _payment = payment;
        }

        public PaymentServiceAssert HaveAllPaymentsPaid()
        {
            _payments.ForEach(x => x.IsPaid.Should().BeTrue());
            return this;
        }

        public PaymentServiceAssert HavePaidAmount(double amount)
        {
            _payment.PaidAmount.Should().Be(amount);
            return this;
        }
    }

    public static class PaymentListAssertExtensions
    {
        public static PaymentServiceAssert Should(this List<Payment> payments)
        {
            return new PaymentServiceAssert(payments);
        }
    }

    public static class PaymentAssertExtensions
    {
        public static PaymentServiceAssert Should(this Payment payment)
        {
            return new PaymentServiceAssert(payment);
        }
    }
}
