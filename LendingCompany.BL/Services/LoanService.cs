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

        public LoanService(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IList<Payment>> CalculatePayments(Loan loan)
        {
            var installmentBaseAmount = 
                (loan.Amount + loan.Amount * (loan.Interest / 100)) / loan.NumberOfInstallments;
            installmentBaseAmount = Math.Round(installmentBaseAmount, 2);

            var payments = new List<Payment>();

            for (var i = 1; i <= loan.NumberOfInstallments; i++)
            {
                var baseAmount = installmentBaseAmount;
                if (i == loan.NumberOfInstallments)
                {
                    if (installmentBaseAmount * loan.NumberOfInstallments < loan.Amount)
                    {
                        baseAmount = installmentBaseAmount + loan.Amount -
                                     installmentBaseAmount * loan.NumberOfInstallments;
                    }
                }
                var payment = await _paymentService.CreatePayment(baseAmount, loan.CreationDate, loan.Id);
                payments.Add(payment);
            }
            await _uow.CompleteAsync();
            return payments;
        }
    }
}
