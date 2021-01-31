using System;
using System.Threading;
using System.Threading.Tasks;
using LendingCompany.BL.Model.Dtos;
using LendingCompany.BL.Model.Messages.Commands;
using LendingCompany.Domain.Model;
using MediatR;

namespace LendingCompany.BL.Handlers
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, BaseResponse<CreateLoanDto>>
    {
        public Task<BaseResponse<CreateLoanDto>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
