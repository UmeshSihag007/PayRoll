using ApwPayroll_Domain.Entities.Holidays.HolidayTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Holidays.HolidayTypes;

public class HolidayTypeConfiguration : IEntityTypeConfiguration<HolidayType>
{
    public void Configure(EntityTypeBuilder<HolidayType> builder)
    {
        builder.Property(x => x.IsActive).HasDefaultValue(true);
    }
}

