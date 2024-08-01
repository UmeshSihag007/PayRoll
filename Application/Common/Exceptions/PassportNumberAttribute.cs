using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Common.Exceptions
{
    public class PassportNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var passportNumber = value as string;
            if (passportNumber == null) return ValidationResult.Success;

            // Passport number format varies by country, so we'll provide a basic format check
            // You can modify or extend this to accommodate specific country formats
            var regex = new Regex(@"^[A-Z]{1,2}[0-9]{6,8}[A-Z]{1,2}$");
            if (!regex.IsMatch(passportNumber))
            {
                return new ValidationResult("Invalid Passport number format. It should be a combination of letters and numbers.");
            }

             

            return ValidationResult.Success;
        }

         
    }
}
