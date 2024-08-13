using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApwPayroll_Application.Common.Exceptions
{
    public class UanNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var uan = value as string;
            if (uan == null) return ValidationResult.Success;

            // UAN format: 12-digit number
            var regex = new Regex(@"^[0-9]{12}$");
            if (!regex.IsMatch(uan))
            {
                return new ValidationResult("Invalid UAN format. It should be a 12-digit number.");
            } 
            return ValidationResult.Success;
        }
    }
}
