using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Banks.Branches.BranchAddresses
{
    public class BranchAddress:BaseAuditEntity
    {
        public int BranchId {  get; set; } 
        public  Branch Branch { get; set; }

        public int CityId { get; set; }
        public  int StateId { get; set; }
        public int LocatioinId {  get; set; }
    }
}
