using LendingCompany.BL.Model.Dtos;
using LendingCompany.Domain.Model;
using LendingCompany.Domain.Model.Messages;

namespace LendingCompany.BL.Model.Messages.Commands
{
    public class CreateLoanCommand : ICommand<BaseResponse<CreateLoanDto>>
    {
        public int NumberOfInstallments { get; set; }
        public double Amount { get; set; }
        public double Interest { get; set; }
    }
}
