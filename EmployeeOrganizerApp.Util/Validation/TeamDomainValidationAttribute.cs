using EmployeeManager.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeOrganizerApp.Util.Validation
{
    public class TeamDomainValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? compareValue = (string?)value;

            return (
                (
                compareValue.ToUpper() == Constants.TeamDropdownContent.Mobile.ToString().ToUpper() ||
                compareValue.ToUpper() == Constants.TeamDropdownContent.Backend.ToString().ToUpper() ||
                compareValue.ToUpper() == Constants.TeamDropdownContent.Frontend.ToString().ToUpper() ||
                String.IsNullOrWhiteSpace(compareValue)
                )
                ? ValidationResult.Success : new ValidationResult(errorMessage: "Invalid domain. Team must be Mobile, Backend, Frontend or null")
            );
        }
    }
}
