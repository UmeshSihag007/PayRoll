using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeExperiences
{
    public class EmployeeExperience:BaseAuditEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string ComanyName { get; set; }
        public string ComanyAddress { get; set; }
        public string Designation {  get; set; }
        public string Industry { get; set; }
        public string EmployeeCode { get; set; }
        public decimal AnnualInCome { get; set; }
        public string InsuranceNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletedDate { get; set; }

    }
}
