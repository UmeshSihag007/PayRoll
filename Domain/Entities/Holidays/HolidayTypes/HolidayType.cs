using ApwPayroll_Domain.common;

namespace ApwPayroll_Domain.Entities.Holidays.HolidayTypes;

public class HolidayType : BaseAuditEntity
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
