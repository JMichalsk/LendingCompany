using System;
using LendingCompany.Domain.Model;

namespace LendingCompany.BL.Model
{
    public class Payment : Entity
    {
        public Payment(double baseAmount, DateTime finalPaymentDate, Guid loadId)
        {
            BaseAmount = baseAmount;
            FinalPaymentDate = finalPaymentDate;
            LoanId = loadId;
        }

        private double _paidAmount;
        public double BaseAmount { get; }
        public double PenaltyAmount { get; set; }
        public double PaidAmount
        {
            get => _paidAmount;
            private set
            {
                IsPaid = value >= BaseAmount + PaidAmount;
                _paidAmount = value;
            }
        }
        public DateTime LastPaymentDate { get; private set; }
        public DateTime FinalPaymentDate { get; }
        public bool IsPaid { get; private set; }
        public Guid LoanId { get; }

        public double Pay(double amount)
        {
            LastPaymentDate = DateTime.UtcNow;
            var sumOfPayments = PaidAmount + amount;
            var toPay = BaseAmount + PenaltyAmount;

            if (sumOfPayments > toPay)
            {
                PaidAmount = BaseAmount + PenaltyAmount;
                return sumOfPayments - BaseAmount;
            }
            PaidAmount = sumOfPayments;
            return 0;
        }
    }
}
