using System.Collections.Generic;
using System.Threading.Tasks;
using LendingCompany.BL.Model;

namespace LendingCompany.BL.Services.Interfaces
{
    public interface ILoanService
    {
        Task<Loan> CalculatePayments(Loan loan);
        double CalculateLoanCost(Loan loan);
    }
}
