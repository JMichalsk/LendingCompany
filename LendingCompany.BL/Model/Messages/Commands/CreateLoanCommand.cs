using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LendingCompany.BL.Model.Dtos;
using LendingCompany.Domain.Model;
using LendingCompany.Domain.Model.Messages;

namespace LendingCompany.BL.Model.Messages.Commands
{
    public class CreateLoanCommand : ICommand<BaseResponse<CreateLoanDto>>
    {
        [Required]
        [DefaultValue(false)]
        public int NumberOfInstallments { get; set; }
        [Required]
        [DefaultValue(false)]
        public double Amount { get; set; }
        [Required]
        public double Interest { get; set; }
        [Required] 
        public Guid PersonId { get; set; }
    }
}
