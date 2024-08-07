using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.LeaveStatuses;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;

namespace ApwPayroll_Domain.Entities.Leaves;

public class Leave : BaseAuditEntity
{
    public int LeaveTypeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public string Reason { get; set; }
    public long ContactNumber { get; set; }
    public bool IsPaid { get; set; }
    public DateTime RequestedDate { get; set; }
    public LeaveStatusEnum LeaveStatus { get; set; }
    public bool IsHalfDay { get; set; }
}
