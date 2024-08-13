using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Common.Exceptions
{
    public class RationCardNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var rationCardNumber = value as string;
            if (rationCardNumber == null) return ValidationResult.Success;

            // Ration Card number format varies by state, so we'll provide a basic format check
            // You can modify or extend this to accommodate specific state formats
            var regex = new Regex(@"^[0-9]{12}$");
            if (!regex.IsMatch(rationCardNumber))
            {
                return new ValidationResult("Invalid Ration Card number format. It should consist of exactly twelve digits.");
            }

            
             

            return ValidationResult.Success;
        } 
    }
}
