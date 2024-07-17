using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.Entities.RelationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeFamiles
{
    public class EmployeeFamily:BaseAuditEntity
    {
        public string Name { get; set; }    
        public int RelationTypeId {  get; set; } 
        public RelationType RelationType { get; set; }
        public  DateTime DOB {  get; set; }
        public GenderEnum Gender { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool IsActive { get; set; }
  
    }
}
