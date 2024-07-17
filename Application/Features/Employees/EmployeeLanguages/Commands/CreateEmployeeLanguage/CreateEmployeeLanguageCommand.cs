using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.common.Enums.Languages;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeLanguages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeLanguages.Commands.CreateEmployeeLanguage
{
    public class CreateEmployeeLanguageCommand
    {
        public int EmployeeId { get; set; }
        public LanguageEnum Language { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
        public bool IsSpeak { get; set; }
        public bool IsPrimary { get; set; }
    }
}
