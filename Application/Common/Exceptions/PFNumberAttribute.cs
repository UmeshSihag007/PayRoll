 
﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Logging;

public class PFNumberAttribute : ValidationAttribute
{
    private readonly ILogger<PFNumberAttribute> _logger;

    public PFNumberAttribute()
    {
        _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<PFNumberAttribute>();
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var pfNumber = value as string;
        if (string.IsNullOrEmpty(pfNumber)) return ValidationResult.Success;

        _logger.LogInformation($"Validating PFNumber: {pfNumber}");

        var regex = new Regex(@"^[A-Z]{2}[0-9]{7}[A-Z]{1}$");
        if (!regex.IsMatch(pfNumber))
        {
            return new ValidationResult("Invalid PF number format. It should be in the format of XX1234567X.");
        }

        return ValidationResult.Success;
 
    }
}
