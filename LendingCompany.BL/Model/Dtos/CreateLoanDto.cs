using System;
using System.Collections.Generic;

namespace LendingCompany.BL.Model.Dtos
{
    public class CreateLoanDto
    {
        public Guid Id { get; set; }
        public IEnumerable<PaymentDto> Payments { get; set; }
        public double TotalCost { get; set; }
    }
}
