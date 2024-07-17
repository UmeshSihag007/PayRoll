using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.GradeTypeEnums;
using ApwPayroll_Domain.Entities.Employees.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeQualifications
{
    public class EmployeeQualification:BaseAuditEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public  string? Institution {  get; set; }

        public int? LocationId { get; set; }
        public  string? UniversityBoard {  get; set; } 

        public decimal ObtainMarks { get; set; }
        public decimal TotalMarks { get; set; }

        public GradeTypeEnum? GradeType { get; set; }

        public string Specification {  get; set; }
        public int FromDate { get; set; }
        public int ToDate { get; set; }
    }
}
