using ApwPayroll_Domain.Entities.Leaves.LeaveTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Leaves.LeaveTypes;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.Property(x => x.IsActive).HasDefaultValue(true);
        builder.HasMany(x => x.LeaveTypeRole)
               .WithOne(x => x.LeaveType)
               .HasForeignKey(x => x.LeaveTypeId)
               .OnDelete(DeleteBehavior.Cascade);


    }
}
