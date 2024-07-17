using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeLanguages
{
    public class EmployeeLanguage:BaseAuditEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public LanguageEnum Language { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
        public bool IsSpeak { get; set; }
        public bool IsPrimary { get; set; }

    }
}
