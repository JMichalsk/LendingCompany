using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LendingCompany.BL.Model.Dtos;
using LendingCompany.Domain.Model;
using LendingCompany.Domain.Model.Messages;

namespace LendingCompany.BL.Model.Messages.Commands
{
    public class PayForLoanCommand : ICommand<BaseResponse<PayForLoanDto>>

    {
        [Required]
        public Guid LoanId { get; set; }
        [Required]
        [DefaultValue(false)]
        public double Amount { get; set; }
    }
}
