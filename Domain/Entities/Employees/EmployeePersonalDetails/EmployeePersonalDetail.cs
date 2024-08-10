    using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.BloodGroup;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.MarriedStatus;
using ApwPayroll_Domain.common.Enums.Religions;
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
        public ReligionEnum? Religion { get; set; }
        public BloodGroupEnum? BloodGroup { get; set; }
        public MarriedStatusEnum MarriedStatus { get; set; }
        public DateTime? DateOfWedding { get; set; }
        public bool IsActive { get; set; }

     
        public EmployeePersonalDetail(int employeeId, Employee employee, DateTime dOB, GenderEnum gender, string? placeOfBirth, ReligionEnum? religion, BloodGroupEnum? bloodGroup, MarriedStatusEnum marriedStatus, DateTime? dateOfWedding, bool isActive)
        {
            EmployeeId = employeeId;
            Employee = employee;
            DOB = dOB;
            Gender = gender;
            PlaceOfBirth = placeOfBirth;
            Religion = religion;
            BloodGroup = bloodGroup;
            MarriedStatus = marriedStatus;
            DateOfWedding = dateOfWedding;
            IsActive = isActive;
        }
        public EmployeePersonalDetail()
        {
            
        }
    }
}
