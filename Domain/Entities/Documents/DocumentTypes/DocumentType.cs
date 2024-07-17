using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Documents.DocumentTypes
{
    public class DocumentType:BaseAuditEntity
    {
        public  string Name { get; set; }
        public string Description { get; set; }

    }
}
