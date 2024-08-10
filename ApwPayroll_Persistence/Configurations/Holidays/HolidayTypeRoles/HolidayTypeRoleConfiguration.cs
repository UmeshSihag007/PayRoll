using ApwPayroll_Domain.Entities.Holidays.HolidayTypeRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Holidays.HolidayTypeRoles;

public class HolidayTypeRoleConfiguration : IEntityTypeConfiguration<HolidayTypeRule>
{
    public void Configure(EntityTypeBuilder<HolidayTypeRule> builder)
    {
        builder.Property(e => e.HolidayId)
            .IsRequired();

        builder.Property(e => e.BranchId)
            .IsRequired(false);

        builder.HasOne(bd => bd.Holiday)
               .WithMany(x=>x.HolidayTypeRules)
               .HasForeignKey(bd => bd.HolidayId)
               .IsRequired(true);

        builder.HasOne(e => e.Branch)
            .WithMany()
            .HasForeignKey(e => e.BranchId)
        .IsRequired(false);

    }

}


