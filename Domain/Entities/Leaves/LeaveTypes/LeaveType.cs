using ApwPayroll_Domain.common;

namespace ApwPayroll_Domain.Entities.Leaves.LeaveTypes;

public class LeaveType : BaseAuditEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}

