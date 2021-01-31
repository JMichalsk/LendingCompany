using System;
using System.ComponentModel.DataAnnotations;
using LendingCompany.BL.Attributes;
using LendingCompany.BL.Model.Dtos;
using LendingCompany.Domain.Model;
using LendingCompany.Domain.Model.Messages;

namespace LendingCompany.BL.Model.Messages.Commands
{
    public class CreatePersonCommand : ICommand<BaseResponse<CreatePersonDto>>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [AgeValidation(18, ErrorMessage = "Person is too young")]
        [DisplayFormat(DataFormatString = "{dd/mm/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(11)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Pesel has to be numeric")]
        public string Pesel { get; set; }
    }
}
