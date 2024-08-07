using ApwPayroll_Domain.Entities.Holidays.HolidatTypeRuleLocations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Holidays.HolidatTypeRoleLocations;

public class HolidayTypeRoleLocationConfiguration : IEntityTypeConfiguration<HolidayTypeRuleLocation>

{
    public void Configure(EntityTypeBuilder<HolidayTypeRuleLocation> builder)
    {
        builder.HasKey(bd => new { bd.LocationId, bd.HolidayRuleTypeId });
        builder.HasOne(bd => bd.Location)
               .WithMany()
               .HasForeignKey(bd => bd.LocationId);
        builder.HasOne(bd => bd.HolidayRuleType)
               .WithMany()
               .HasForeignKey(bd => bd.HolidayRuleTypeId);
    }
}
