using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ApwPayroll_Application.Common.Exceptions
{
    public class EmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();

                // Simple email pattern matching
                string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

                if (!Regex.IsMatch(email, emailPattern))
                {
                    return new ValidationResult("Please enter a valid email address.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
