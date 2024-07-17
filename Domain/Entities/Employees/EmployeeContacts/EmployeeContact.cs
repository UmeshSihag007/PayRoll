using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees.ContactTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeContacts
{
    public class EmployeeContact:BaseAuditEntity
    {

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int ContactTypeId { get; set; }
        public ContactType ContactType { get; set; }

        public Int64 MobileNumber { get; set; }
        public Int64 WhatsAppNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
