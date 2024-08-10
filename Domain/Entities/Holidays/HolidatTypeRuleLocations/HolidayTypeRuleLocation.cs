using ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;
using ApwPayroll_Domain.Entities.Locations;

namespace ApwPayroll_Domain.Entities.Holidays.HolidatTypeRuleLocations;

public class HolidayTypeRuleLocation
{
    public int LocationId { get; set; }
    public Location Location { get; set; }
    public int HolidayRuleTypeId { get; set; }
    public HolidayTypeRule HolidayRuleType { get; set; }

    public bool IsActive { get; set; } = true;

    public HolidayTypeRuleLocation(int locationId, int holidayRuleTypeId)
    {
        LocationId = locationId;
        HolidayRuleTypeId = holidayRuleTypeId;
    }

    public HolidayTypeRuleLocation()
    {

    }

}
