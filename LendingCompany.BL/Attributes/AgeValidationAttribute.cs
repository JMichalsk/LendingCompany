using System;
using System.ComponentModel.DataAnnotations;

namespace LendingCompany.BL.Attributes
{
    public class AgeValidationAttribute : ValidationAttribute
    {
        private readonly int _minimumAge;

        public AgeValidationAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
        }

        public override bool IsValid(object value)
        {
            if (DateTime.TryParse(value.ToString(), out var date))
            {
                return date.AddYears(_minimumAge) < DateTime.Now;
            }

            return false;
        }
    }
}
