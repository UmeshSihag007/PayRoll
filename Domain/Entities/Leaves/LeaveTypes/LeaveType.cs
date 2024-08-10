using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypeRoles;

namespace ApwPayroll_Domain.Entities.Leaves.LeaveTypes;

public class LeaveType : BaseAuditEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }

    public List< LeaveTypeRule>? LeaveTypeRole { get; set; }
}

