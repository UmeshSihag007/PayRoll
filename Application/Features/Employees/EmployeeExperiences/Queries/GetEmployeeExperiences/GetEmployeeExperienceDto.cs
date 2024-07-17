using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeExperiences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeExperiences.Queries.GetEmployeeExperiences
{
    public class GetEmployeeExperienceDto:IMapFrom<EmployeeExperience>
    {
        public int Id { get; set; } 
        public int EmployeeId { get; set; }
        public string ComanyName { get; set; }
        public string ComanyAddress { get; set; }
        public string Designation { get; set; }
        public string Industry { get; set; }
        public string EmployeeCode { get; set; }
        public decimal AnnualInCome { get; set; }
        public string InsuranceNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletedDate { get; set; }
    }
}
