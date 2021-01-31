using System;
using System.Threading.Tasks;
using LendingCompany.BL.Model;

namespace LendingCompany.BL.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreatePayment(Guid loanId, double baseAmount, DateTime loanCreationDate);
        Task<double> FoundPayment(Guid loanId, double amount);
    }
}
