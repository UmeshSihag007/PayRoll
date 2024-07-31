using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Common.Exceptions
{
    public class VoterIdAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var voterId = value as string;
            if (voterId == null) return ValidationResult.Success;

            // Voter ID format varies by country/state, so we'll provide a basic format check
            // You can modify or extend this to accommodate specific country/state formats
            var regex = new Regex(@"^[A-Z]{3}[0-9]{7}$");
            if (!regex.IsMatch(voterId))
            {
                return new ValidationResult("Invalid Voter ID format. It should be a combination of letters and numbers.");
            }

            
            return ValidationResult.Success;
        }

        
    }
}
