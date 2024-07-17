using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Banks.Branches.BranchContacts
{
    public class BranchContact:BaseAuditEntity
    {
        public int BranchId { get; set; }   
        public Branch Branch { get; set; }

        public Int64 MobileNumber { get; set; }
        public string EmailId {  get; set; }

    }
}
