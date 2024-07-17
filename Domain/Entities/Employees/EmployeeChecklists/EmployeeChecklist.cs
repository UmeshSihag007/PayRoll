using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees.Checklists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeChecklists
{
    public class EmployeeChecklist:BaseAuditEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int  CheckListId { get; set; }
        public Checklist Checklist { get; set; }
        public bool IsApproved {  get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool IsActive { get; set; }  
    }
}
