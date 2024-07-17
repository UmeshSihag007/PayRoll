using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.common.Enums.GradeTypeEnums;
using ApwPayroll_Domain.Entities.Employees.Courses;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.Employees.EmployeeQualifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeEducations.Quories
{
    public class GetEmployeeQualificationDto : IMapFrom<EmployeeQualification>
    {
        public int EmployeeId { get; set; }

        public int CourseId { get; set; }

        public string? Institution { get; set; }

        public int? LocationId { get; set; }
        public string? UniversityBoard { get; set; }

        public decimal Marks { get; set; }

        public GradeTypeEnum? GradeType { get; set; }

        public string Specification { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
    }
}
