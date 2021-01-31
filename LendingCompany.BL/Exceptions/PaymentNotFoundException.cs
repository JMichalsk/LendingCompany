using System;

namespace LendingCompany.BL.Exceptions
{
    public class PaymentNotFoundException : Exception
    {
        public PaymentNotFoundException()
        {
        }

        public PaymentNotFoundException(string message) : base(message)
        {
        }
    }
}
