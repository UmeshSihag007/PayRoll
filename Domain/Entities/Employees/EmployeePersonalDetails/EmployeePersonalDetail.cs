    using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.BloodGroup;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.MarriedStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails
{
    public class EmployeePersonalDetail : BaseAuditEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime DOB { get; set; }
        public GenderEnum Gender { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Religion { get; set; }
        public BloodGroupEnum BloodGroup { get; set; }
        public MarriedStatusEnum MarriedStatus { get; set; }
        public DateTime? DateOfWedding { get; set; }
        public bool IsActive { get; set; }
    }
}
