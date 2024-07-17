using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.Certificates
{
    public  class Certificate:BaseAuditEntity
    {
        public string Name {  get; set; }
        public int DocumentId { get; set; }
            
        public  Document Document { get; set; }
        public bool  IsActive { get; set; }
    }
}
