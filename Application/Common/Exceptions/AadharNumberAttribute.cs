using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Common.Exceptions
{
    public class AadharNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var aadharNumber = value as string;
            if (aadharNumber == null) return ValidationResult.Success;

            var regex = new Regex(@"^[2-9]{1}[0-9]{11}$");
            if (!regex.IsMatch(aadharNumber))
            {
                return new ValidationResult("Invalid Aadhaar number format. It should be a 12-digit number.");
            }

            // Additional validation: Verify check digit
            var digits = aadharNumber.ToCharArray();
            int sum = 0;
            for (int i = 0; i < 11; i++)
            {
                int digit = int.Parse(digits[i].ToString());
                sum += (digit * (i % 2 == 0 ? 2 : 1));
            }
            int checkDigit = sum % 10;
            if (checkDigit != int.Parse(digits[11].ToString()))
            {
                return new ValidationResult("Invalid Aadhaar number. The check digit is incorrect.");
            }

            return ValidationResult.Success;
        }
    }
}
