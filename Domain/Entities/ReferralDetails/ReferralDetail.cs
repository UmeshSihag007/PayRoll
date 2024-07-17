using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees;

namespace ApwPayroll_Domain.Entities.ReferralDetails
{
    public class ReferralDetail : BaseAuditEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string ReferenceName { get; set; }
        public string Designation { get; set; }

        public string OrganizationName { get; set; }
        public long ContactNumber { get; set; }
        public int YearsOfAcquaintance { get; set; }
    }
}
