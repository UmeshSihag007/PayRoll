using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.Gender;
using ApwPayroll_Domain.Entities.Banks.Branches;
using ApwPayroll_Domain.Entities.Holidays.HolidatTypeRuleLocations;

namespace ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;

public class HolidayTypeRule : BaseAuditEntity
{
    public int HolidayId { get; set; }
    public Holiday Holiday { get; set; }
    public GenderEnum? Gender { get; set; }
    public int? BranchId { get; set; }
    public Branch Branch { get; set; }
    public List<HolidayTypeRuleLocation> HolidayTypeRuleLocations { get; set; } = new List<HolidayTypeRuleLocation>();

    public void AddLocation(int locationId)
    {
        HolidayTypeRuleLocations.Add(new HolidayTypeRuleLocation(locationId, Id));
    }


    public void AddIfNotLocationExists(List<int> locationId)
    {
        foreach (var location in locationId)
        {
            if (HolidayTypeRuleLocations.All(pu => pu.LocationId != location))
            {
                HolidayTypeRuleLocations.Add(new HolidayTypeRuleLocation(location, Id));
            }
        }
        RemoveDesignationExists(locationId);
    }

    private void RemoveDesignationExists(List<int> locationId)
    {
        foreach (var location in HolidayTypeRuleLocations)
        {
            if (!locationId.Contains(location.LocationId))
            {
                location.IsActive = false;
            }
        }
    }

}