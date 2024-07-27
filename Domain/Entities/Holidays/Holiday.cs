using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;

namespace ApwPayroll_Domain.Entities.Holidays;

public class Holiday : BaseAuditEntity
{
    public string Name { get; set; }
    public DateTime ToDate { get; set; }
    public DateTime FromDate { get; set; }
    public bool IsNotifyToEmployee { get; set; }
    public bool IsResetToLeaveRequest { get; set; }
    public string Description { get; set; }
    public int HolidayTypeId { get; set; }
    public HolidayType HolidayType { get; set; }
}
