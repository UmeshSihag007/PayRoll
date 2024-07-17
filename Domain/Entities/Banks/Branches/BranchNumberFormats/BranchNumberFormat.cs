using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.FormatTypes;

namespace ApwPayroll_Domain.Entities.Banks.Branches.BranchNumberFormats
{
    public class BranchNumberFormat : BaseAuditEntity
    {
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public FormatType FormatType { get; set; }
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int NextNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
