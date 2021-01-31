using System;
using System.Threading.Tasks;
using LendingCompany.BL.Model;

namespace LendingCompany.BL.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> CreatePayment(double baseAmount, DateTime loanCreationDate, Guid loanId);
    }
}
