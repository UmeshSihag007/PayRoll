using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeLicenses
{
    public class EmployeeLicense:BaseAuditEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
