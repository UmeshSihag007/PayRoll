using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Banks.Branches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Branches.Queries.GetAllBranches
{
    public class GetBranchDto:IMapFrom<Branch>
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
