using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.common.Enums.LeaveStatuses;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;

namespace ApwPayroll_Application.Features.Leaves.Queries.GetLeaveAllDto;

public class LeaveAllDto
{
    public  int  Id { get; set; }
    public int LeaveTypeId { get; set; }
    public LeaveType LeaveType { get; set; }
    public string Reason { get; set; }
    public long ContactNumber { get; set; }
    public Designation? Designation { get; set; }
    public DateTime ToDate { get; set; }
    public DateTime FromDate { get; set; }
    public bool IsPaid { get; set; }
    public DateTime RequestedDate { get; set; } = DateTime.Now;
    public LeaveStatusEnum LeaveStatus { get; set; }
    public bool IsHalfDay { get; set; }
    public GenderEnum? Gender { get; set; }
    public int? DesignationId { get; set; }
    public int? BranchId { get; set; }
    public long? MaxMonthLeave { get; set; }
    public long? MaxYearLeave { get; set; }
    public int? ResponseById { get; set; }
    public string? ResponseRemark { get; set; }
    public DateTime? ResponseDate { get; set; }
    public int? ForwordId { get; set; }
}
