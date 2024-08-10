using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Designations;
using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;

namespace ApwPayroll_Domain.Entities.Leaves.LeaveTypeRoles;

public class LeaveTypeRule : BaseAuditEntity
{
    public int? LeaveTypeId { get; set; }
    public LeaveType? LeaveType { get; set; }
    public GenderEnum? Gender { get; set; }
    public int? DesignationId { get; set; }
    public Designation? Designation { get; set; }
    public int? BranchId { get; set; }
    public Branch? Branch { get; set; }
    public long? MaxMonthLeave { get; set; }
    public long? MaxYearLeave { get; set; }  
}
