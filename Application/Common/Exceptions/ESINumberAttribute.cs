using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApwPayroll_Application.Common.Exceptions
{
 
    public class ESINumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var esiNumber = value as string;
 
            if (string.IsNullOrEmpty(esiNumber)) return ValidationResult.Success;
 
 

            var regex = new Regex(@"^[A-Z]{2}[0-9]{7,9}$");
            if (!regex.IsMatch(esiNumber))
            {
                return new ValidationResult("Invalid ESINumber format. It should be in the format of XX1234567 or XX123456789.");
            }

            return ValidationResult.Success;
        }
    }
 
 
}
