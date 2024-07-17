using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.ContactTypes
{
    public class ContactType:BaseAuditEntity
    {
        public  string Name {  get; set; }
        public bool IsActive { get; set; }
    }
}
