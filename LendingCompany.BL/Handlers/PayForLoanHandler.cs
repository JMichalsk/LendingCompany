using System.Threading;
using System.Threading.Tasks;
using LendingCompany.BL.Model.Dtos;
using LendingCompany.BL.Model.Messages.Commands;
using LendingCompany.BL.Services.Interfaces;
using LendingCompany.Domain.Model;
using MediatR;

namespace LendingCompany.BL.Handlers
{
    public class PayForLoanHandler : IRequestHandler<PayForLoanCommand, BaseResponse<PayForLoanDto>>
    {
        private readonly IPaymentService _paymentService;

        public PayForLoanHandler(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<BaseResponse<PayForLoanDto>> Handle(PayForLoanCommand request, CancellationToken cancellationToken)
        {
            var change = await _paymentService.FoundPayment(request.LoanId, request.Amount);
            return new BaseResponse<PayForLoanDto>(new PayForLoanDto()
            {
                Change = change
            });
        }
    }
}
