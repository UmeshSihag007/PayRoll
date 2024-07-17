using ApwPayroll_Domain.Entities.Employees.ContactTypes;
using ApwPayroll_Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeContact.Commands.CreateEmployeeContact
{
    public class CreateEmployeeContactCommand
    {
        public int EmployeeId { get; set; }
        public int ContactTypeId { get; set; }
        public Int64 MobileNumber { get; set; }
        public Int64 WhatsAppNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
