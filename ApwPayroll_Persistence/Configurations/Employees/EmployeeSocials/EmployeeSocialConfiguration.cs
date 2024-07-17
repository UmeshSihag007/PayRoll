using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeSocials
{
    public class EmployeeSocialConfiguration : IEntityTypeConfiguration<EmployeeSocial>
    {


        public void Configure(EntityTypeBuilder<EmployeeSocial> builder)
        {

            builder.HasOne(bd => bd.Employee)
                   .WithMany()
                   .HasForeignKey(bd => bd.EmployeeId);

        }
    }
}
