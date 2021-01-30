using MediatR;

namespace LendingCompany.Domain.Model.Messages
{
    public interface IQuery<out T> : IRequest<T>
    {
    }
}
