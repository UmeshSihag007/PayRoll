using System.ComponentModel.DataAnnotations;

namespace ApwPayroll_Application.Common.Exceptions
{
    public class MobileNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string phoneNumber = value.ToString();

                if (phoneNumber.Length != 10)
                {
                    return new ValidationResult("Phone number must be 10 digits.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
