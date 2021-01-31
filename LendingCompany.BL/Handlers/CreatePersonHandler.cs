using System;
using System.Threading;
using System.Threading.Tasks;
using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;
using LendingCompany.BL.Model.Dtos;
using LendingCompany.BL.Model.Messages.Commands;
using LendingCompany.Domain.Model;
using MediatR;

namespace LendingCompany.BL.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, BaseResponse<CreatePersonDto>>
    {
        private readonly IPersonRepository _personRepository;

        public CreatePersonHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<BaseResponse<CreatePersonDto>> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var personId = await _personRepository.CreatePersonAsync(
                    new Person(request.FirstName, request.LastName, request.DateOfBirth, request.Pesel));

                return new BaseResponse<CreatePersonDto>(new CreatePersonDto()
                {
                    Id = personId
                });
            }
            catch (Exception e)
            {
                // there should be logging
                return new BaseResponse<CreatePersonDto>("An error occurred when handling request.");
            }
        }
    }
}
