using System.Threading.Tasks;
using LendingCompany.BL.Externals;

namespace LendingCompany.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LendingCompanyDataContext _dbContext;

        public UnitOfWork(LendingCompanyDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
