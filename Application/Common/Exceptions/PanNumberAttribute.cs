using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApwPayroll_Application.Common.Exceptions
{
    public class PanNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var panNumber = value as string;
            if (panNumber == null) return ValidationResult.Success;

            var regex = new Regex(@"^[A-Z]{5}[0-9]{4}[A-Z]{1}$");
            if (!regex.IsMatch(panNumber))
            {
                return new ValidationResult("Invalid PAN format. It should be in the format of ABCDE1234F.");
            }

            return ValidationResult.Success;
        }
    }
}
