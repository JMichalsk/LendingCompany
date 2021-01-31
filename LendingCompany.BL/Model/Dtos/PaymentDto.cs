using System;

namespace LendingCompany.BL.Model.Dtos
{
    public class PaymentDto
    {
        public DateTime FinalPaymentDate { get; set; }
        public double BaseAmount { get; set; }
    }
}
