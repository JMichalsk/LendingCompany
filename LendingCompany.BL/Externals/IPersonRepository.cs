using System;
using System.Threading.Tasks;
using LendingCompany.BL.Model;

namespace LendingCompany.BL.Externals
{
    public interface IPersonRepository
    {
        Task<Guid> CreatePersonAsync(Person person);
    }
}
