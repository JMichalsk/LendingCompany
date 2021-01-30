using MediatR;

namespace LendingCompany.Domain.Model.Messages
{
    public interface ICommand<out T> : IRequest<T>
    {
    }
}
