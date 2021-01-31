using System;

namespace LendingCompany.BL.Model.Dtos
{
    public class CreateLoanDto
    {
        public Guid Id { get; set; }
        public double InstallmentAmount { get; set; }
    }
}
