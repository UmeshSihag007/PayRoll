using ApwPayroll_Domain.Entities.Designations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeDesignations
{
    public class EmployeeDesignationConfiguration : IEntityTypeConfiguration<EmployeeDesignation>
    { 

        public void Configure(EntityTypeBuilder<EmployeeDesignation> builder)
        {
            builder.HasKey(bd => new { bd.EmployeeId, bd.DesignationId });


            builder.HasOne(bd => bd.Employee)
                  .WithMany(d => d.EmployeeDesignations)
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.HasOne(bd => bd.Designation)
                     .WithMany(d => d.EmployeeDesignations)
                   .HasForeignKey(bd => bd.DesignationId);
             builder.Property(bd => bd.IsActive).HasDefaultValue(true);

            builder.HasIndex(x => new { x.DesignationId, x.EmployeeId });
        }
    }
}
