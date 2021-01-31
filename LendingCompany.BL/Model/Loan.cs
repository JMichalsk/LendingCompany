using System;
using System.Collections.Generic;
using LendingCompany.Domain.Model;

namespace LendingCompany.BL.Model
{
    public class Loan : Entity
    {
        public Loan(int numberOfInstallments, double interest, double amount)
        {
            CreationDate = DateTime.UtcNow;
            NumberOfInstallments = numberOfInstallments;
            Interest = interest;
            EstimatedRepaymentDate = CreationDate.AddMonths(numberOfInstallments);
            Amount = amount;
        }
        public DateTime CreationDate { get; }
        public DateTime EstimatedRepaymentDate { get; }
        public int NumberOfInstallments { get; }
        public double Amount { get; }
        public double PaidAmount { get; set; }
        public bool IsRepaid { get; set; }
        public int TotalDaysOfDelay { get; set; }
        public double Interest { get; set; }
        public decimal PenaltyAmount { get; set; }
        public DateTime? ActualRepaymentDate { get; set; }
        public IList<Payment> Payments { get; set; }
    }
}
