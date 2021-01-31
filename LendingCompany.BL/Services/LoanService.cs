using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;
using LendingCompany.BL.Services.Interfaces;

namespace LendingCompany.BL.Services
{
    public class LoanService : ILoanService
    {
        private readonly IPaymentService _paymentService;
        private readonly IUnitOfWork _uow;

        public LoanService(IPaymentService paymentService, IUnitOfWork uow)
        {
            _paymentService = paymentService;
            _uow = uow;
        }

        public async Task<Loan> CalculatePayments(Loan loan)
        {
            var totalAmount = loan.Amount + loan.Amount * (loan.Interest / 100);
            var installmentBaseAmount =
                 totalAmount  / loan.NumberOfInstallments;
            installmentBaseAmount = Math.Floor(installmentBaseAmount * 100) / 100;

            var payments = new List<Payment>();

            for (var i = 1; i <= loan.NumberOfInstallments; i++)
            {
                var baseAmount = installmentBaseAmount;
                if (i == loan.NumberOfInstallments)
                {
                    if (installmentBaseAmount * loan.NumberOfInstallments < totalAmount)
                    {
                        baseAmount = totalAmount - installmentBaseAmount * (loan.NumberOfInstallments - 1) ;
                    }
                }
                var payment = await _paymentService.CreatePayment(baseAmount, loan.CreationDate, loan.Id);
                payments.Add(payment);
            }
            await _uow.CompleteAsync();
            loan.Payments = payments;
            return loan;
        }

        public double CalculateLoanCost(Loan loan)
        {
            return loan.Amount * loan.Interest / 100;
        }
    }
}
