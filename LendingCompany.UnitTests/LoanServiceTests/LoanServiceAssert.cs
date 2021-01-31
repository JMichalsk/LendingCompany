using System.Collections.Generic;
using FluentAssertions;
using LendingCompany.BL.Model;

namespace LendingCompany.UnitTests.LoanServiceTests
{
    public class LoanServiceAssert
    {
        private readonly List<Payment> _payments;

        public LoanServiceAssert(Loan loan)
        {
            _payments = (List<Payment>)loan.Payments;
        }

        public LoanServiceAssert HaveValue()
        {
            _payments.Should().NotBeNullOrEmpty();
            return this;
        }

        public LoanServiceAssert HaveNumberOfPayments(int number)
        {
            _payments.Count.Should().Be(number);
            return this;
        }

        public LoanServiceAssert HaveAllPaymentExceptLastWithAmount(double amount)
        {
            _payments.ForEach(x =>
            {
                if (x != _payments.FindLast(x => true))
                    x.BaseAmount.Should().Be(amount);
            });
            return this;
        }

        public LoanServiceAssert HaveLastPaymentWithAmount(double amount)
        {
            _payments.FindLast(x => true)?.BaseAmount.Should().Be(amount);
            return this;
        }

        public LoanServiceAssert HaveAllPaymentsWithAmount(double amount)
        {
            _payments.ForEach(x => x.BaseAmount.Should().Be(amount));
            return this;
        }
    }

    public static class LoadAssertExtensions
    {
        public static LoanServiceAssert Should(this Loan loan)
        {
            return new LoanServiceAssert(loan);
        }
    }
}
