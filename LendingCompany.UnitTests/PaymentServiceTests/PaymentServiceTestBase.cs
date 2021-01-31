using System;
using System.Collections.Generic;
using LendingCompany.BL.Model;
using NUnit.Framework;

namespace LendingCompany.UnitTests.PaymentServiceTests
{
    public class PaymentServiceTestBase
    {
        protected int SaveCount;
        protected List<Payment> Payments;

        public PaymentServiceTestBase()
        {
            Payments = new List<Payment>();
            SaveCount = 0;
        }

        protected Payment CreatePayment(double baseAmount,  Guid loanId, int finalPaymentDaysFromNow = 0, bool isPaid = false)
        {
            var payment = new Payment(baseAmount, DateTime.UtcNow.AddDays(finalPaymentDaysFromNow), loanId);
            if(isPaid == true)
                payment.Pay(baseAmount);
            Payments.Add(payment);
            return payment;
        }

        [TearDown]
        protected void AfterEachTest()
        {
            Console.WriteLine($"Finished test: {TestContext.CurrentContext.Test.Name}.");
            SaveCount = 0;
            Payments = new List<Payment>();
        }
    }
}
