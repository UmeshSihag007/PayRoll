using ApwPayroll_Application.Common.Mappings;
using ApwPayroll_Domain.Entities.Employees;
using ApwPayroll_Domain.Entities.ReferralDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Application.Features.Employees.EmployeeReferences.Queries
{
    public class GetEmployeeReferenceDto : IMapFrom<ReferralDetail>
    {

        public int EmployeeId { get; set; }

        public string ReferenceName { get; set; }
        public string Designation { get; set; }

        public string OrganizationName { get; set; }
        public long ContactNumber { get; set; }
        public int YearsOfAcquaintance { get; set; }
    }
}
