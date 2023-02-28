using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentValidator;

namespace EmployeeOrganizerApp.Util.Validation
{
    public class CpfValidatorAttribute:ValidationAttribute
    {
        public CpfValidatorAttribute() { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            string? compareValue = (string?)value;

            return CpfValidation.Validate(compareValue) ? ValidationResult.Success : new ValidationResult(errorMessage: "CPF is invalid. Please try another input with the right value");


        }
    }
}
