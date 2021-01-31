using System;
using System.Threading.Tasks;
using LendingCompany.BL.Model;

namespace LendingCompany.BL.Externals
{
    public interface IPaymentRepository
    {
        Task<Guid> CreatePaymentAsync(Payment payment);
    }
}
