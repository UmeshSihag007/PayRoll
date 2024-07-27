using ApwPayroll_Domain.Entities.Leaves.LeaveTypeRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Leaves.LeaveTypeRoles;

public class LeaveTypeRoleConfiguration : IEntityTypeConfiguration<LeaveTypeRole>
{
    public void Configure(EntityTypeBuilder<LeaveTypeRole> builder)
    {
        builder.Property(x => x.LeaveTypeId).IsRequired();
        builder.HasOne(x => x.LeaveType)
            .WithMany()
            .HasForeignKey(x => x.LeaveTypeId)
            .IsRequired();
        builder.Property(x => x.DesignationId).IsRequired();
        builder.HasOne(x => x.Designation)
            .WithMany()
            .HasForeignKey(x => x.DesignationId)
            .IsRequired();
        builder.Property(x => x.BranchId).IsRequired();
        builder.HasOne(x => x.Branch)
            .WithMany()
            .HasForeignKey(x => x.BranchId)
            .IsRequired();
    }
}
