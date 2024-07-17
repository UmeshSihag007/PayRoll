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
            var regex = new Regex(@"^[A-Z]{1,2}[0-9]{7,12}$");
            if (!regex.IsMatch(rationCardNumber))
            {
                return new ValidationResult("Invalid Ration Card number format. It should be a combination of letters and numbers.");
            }

            // Additional validation: Check for duplicate characters (some states have this rule)
            if (HasDuplicateCharacters(rationCardNumber))
            {
                return new ValidationResult("Invalid Ration Card number. It should not have duplicate characters.");
            }

            return ValidationResult.Success;
        }

        private bool HasDuplicateCharacters(string input)
        {
            var charArray = input.ToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                for (int j = i + 1; j < charArray.Length; j++)
                {
                    if (charArray[i] == charArray[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
