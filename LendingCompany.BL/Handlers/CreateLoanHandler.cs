using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LendingCompany.BL.Externals;
using LendingCompany.BL.Model;
using LendingCompany.BL.Model.Dtos;
using LendingCompany.BL.Model.Messages.Commands;
using LendingCompany.BL.Services.Interfaces;
using LendingCompany.Domain.Model;
using MediatR;

namespace LendingCompany.BL.Handlers
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, BaseResponse<CreateLoanDto>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;
        public CreateLoanHandler(ILoanRepository loanRepository, ILoanService loanService, IMapper mapper)
        {
            _loanRepository = loanRepository;
            _loanService = loanService;
            _mapper = mapper;
        }

        public async Task<BaseResponse<CreateLoanDto>> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var loan = new Loan(request.NumberOfInstallments, request.Interest, request.Amount);
                var loanId = await _loanRepository.CreateLoanAsync(loan);

                var loanWithPayments = await _loanService.CalculatePayments(loan);
                var paymentDtos = _mapper.Map<IEnumerable<PaymentDto>>(loanWithPayments.Payments);

                var loanCost = _loanService.CalculateLoanCost(loan);

                return new BaseResponse<CreateLoanDto>(new CreateLoanDto()
                {
                    Id = loanId,
                    Payments = paymentDtos,
                    TotalCost = loanCost
                });
            }
            catch (Exception e)
            {
                // there should be logging
                return new BaseResponse<CreateLoanDto>("An error occurred when handling request.");
            }
        }
    }
}
