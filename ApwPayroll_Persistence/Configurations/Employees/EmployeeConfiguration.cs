using ApwPayroll_Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Employees
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.IsLoginAccess).HasDefaultValue(false);

            builder.HasOne(bd => bd.Branch)
                   .WithMany()
                   .HasForeignKey(bd => bd.BranchId);

        }
    }
}
