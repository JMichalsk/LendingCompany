using System;
using System.Collections.Generic;
using LendingCompany.Domain.Model;

namespace LendingCompany.BL.Model
{
    public class Loan : Entity
    {
        public Loan(int numberOfInstalments, double interest, double amount)
        {
            CreationDate = DateTime.UtcNow;
            NumberOfInstalments = numberOfInstalments;
            Interest = interest;
            EstimatedRepaymentDate = CreationDate.AddMonths(numberOfInstalments);
            Amount = amount;
        }
        public DateTime CreationDate { get; }
        public DateTime EstimatedRepaymentDate { get; }
        public int NumberOfInstalments { get; }
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
