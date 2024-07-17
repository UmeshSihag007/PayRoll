using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Common.Exceptions
{
    public class LicenceAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var licenseNumber = value as string;
            if (licenseNumber == null) return ValidationResult.Success;

            // License number format varies by country/state, so we'll provide a basic format check
            // You can modify or extend this to accommodate specific country/state formats
            var regex = new Regex(@"^[A-Z]{2,3}[0-9]{6,8}[A-Z]{1,2}$");
            if (!regex.IsMatch(licenseNumber))
            {
                return new ValidationResult("Invalid License number format. It should be a combination of letters and numbers.");
            }

            // Additional validation: Check for checksum (some states have this rule)
            if (!IsValidChecksum(licenseNumber))
            {
                return new ValidationResult("Invalid License number. The checksum is incorrect.");
            }

            return ValidationResult.Success;
        }

        private bool IsValidChecksum(string licenseNumber)
        {
            // This is a basic example of a checksum calculation
            // You may need to modify or extend this to accommodate specific country/state rules
            var digits = licenseNumber.ToCharArray();
            int sum = 0;
            for (int i = 0; i < digits.Length - 1; i++)
            {
                int digit = int.Parse(digits[i].ToString());
                sum += (digit * (i % 2 == 0 ? 2 : 1));
            }
            int checkDigit = sum % 10;
            if (checkDigit != int.Parse(digits[digits.Length - 1].ToString()))
            {
                return false;
            }
            return true;
        }
    }
}
