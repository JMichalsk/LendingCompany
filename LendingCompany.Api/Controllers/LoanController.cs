using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LendingCompany.BL.Model.Dtos;
using LendingCompany.BL.Model.Messages.Commands;
using LendingCompany.Domain.Model;
using MediatR;

namespace LendingCompany.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<BaseResponse<CreateLoanDto>>> Create(CreateLoanCommand request)
        {
            var result = await _mediator.Send(request);
            if (!result.Success)
                return BadRequest(result);
            return result;
        }
    }
}
