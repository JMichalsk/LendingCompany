using System.Threading.Tasks;
using LendingCompany.BL.Model.Dtos;
using LendingCompany.BL.Model.Messages.Commands;
using LendingCompany.Domain.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LendingCompany.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<BaseResponse<CreatePersonDto>>> Create(CreatePersonCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
                return BadRequest(result);
            return result;
        }
    }
}
