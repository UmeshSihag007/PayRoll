using ApwPayroll_Domain.Entities.Leaves;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Leaves;

public class LeaveConfiguration : IEntityTypeConfiguration<Leave>
{
    public void Configure(EntityTypeBuilder<Leave> builder)
    {
        builder.Property(x => x.LeaveTypeId).IsRequired();
        builder.HasOne(x => x.LeaveType).WithMany().
            HasForeignKey(x => x.LeaveTypeId).IsRequired();

    }
}