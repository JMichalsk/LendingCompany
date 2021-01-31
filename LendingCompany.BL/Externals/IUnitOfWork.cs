using System.Threading.Tasks;

namespace LendingCompany.BL.Externals
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
