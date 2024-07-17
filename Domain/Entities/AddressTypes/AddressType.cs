using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.AddressTypes
{
    public class AddressType:BaseAuditEntity
    {
        public string Name { get; set; }
        public  bool IsActive { get; set; }
    }
}
