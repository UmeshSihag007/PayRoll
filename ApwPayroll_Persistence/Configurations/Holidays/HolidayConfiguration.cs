using ApwPayroll_Domain.Entities.Holidays;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Holidays;

public class HolidayConfiguration : IEntityTypeConfiguration<Holiday>
{
    public void Configure(EntityTypeBuilder<Holiday> builder)
    {
        builder.Property(x => x.Name)
             .IsRequired();

        builder.Property(x => x.HolidayTypeId)
            .IsRequired();
        builder.HasOne(x => x.HolidayType)
            .WithMany()
            .HasForeignKey(x => x.HolidayTypeId)
            .IsRequired();
    }
}
