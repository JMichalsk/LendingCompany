using System;
using System.Threading.Tasks;
using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;

namespace LendingCompany.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly LendingCompanyDataContext _dbContext;
        public PaymentRepository(LendingCompanyDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreatePaymentAsync(Payment payment)
        {
            var result = await _dbContext.Payment.AddAsync(payment);
            return result.Entity.Id;
        }
    }
}
