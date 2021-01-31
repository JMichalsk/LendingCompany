using System;
using System.Threading.Tasks;
using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;

namespace LendingCompany.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly LendingCompanyDataContext _dbContext;
        public PersonRepository(LendingCompanyDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> CreatePersonAsync(Person person)
        {
            var result = await _dbContext.Person.AddAsync(person);
            return result.Entity.Id;
        }
    }
}
