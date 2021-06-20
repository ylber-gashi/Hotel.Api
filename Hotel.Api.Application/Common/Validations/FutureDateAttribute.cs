using System;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Api.Application.Common.Validations
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime time = DateTime.Now;
            DateTime givenTime = Convert.ToDateTime(value);
            if (givenTime<=time)
                return new ValidationResult("Date entered should be in the future.");

            return ValidationResult.Success;
        }
    }

}
