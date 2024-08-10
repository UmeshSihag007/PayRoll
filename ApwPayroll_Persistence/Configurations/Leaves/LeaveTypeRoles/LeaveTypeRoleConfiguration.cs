using ApwPayroll_Domain.Entities.Leaves.LeaveTypeRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Leaves.LeaveTypeRoles;

public class LeaveTypeRoleConfiguration : IEntityTypeConfiguration<LeaveTypeRule>
{
    public void Configure(EntityTypeBuilder<LeaveTypeRule> builder)
    {
        builder.Property(x => x.LeaveTypeId).IsRequired(false);
        builder.HasOne(x => x.LeaveType)
            .WithMany()
            .HasForeignKey(x => x.LeaveTypeId)
            .IsRequired(false);

        builder.Property(x => x.DesignationId).IsRequired(false);
        builder.HasOne(x => x.Designation)
            .WithMany()
            .HasForeignKey(x => x.DesignationId)
            .IsRequired(false);

        builder.Property(x => x.BranchId).IsRequired(false);
        builder.HasOne(x => x.Branch)
            .WithMany()
            .HasForeignKey(x => x.BranchId)
            .IsRequired(false);
    }

}
