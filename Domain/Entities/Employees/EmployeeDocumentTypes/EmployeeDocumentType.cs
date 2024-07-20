using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes
{
    public class EmployeeDocumentType:BaseAuditEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Heading { get; set; }
        public bool IsCodeShow { get; set; }
        public  int OrderNo { get; set; }
    }
}
