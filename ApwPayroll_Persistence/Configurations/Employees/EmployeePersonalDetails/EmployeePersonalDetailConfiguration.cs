using ApwPayroll_Domain.Entities.Employees.EmployeePersonalDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Employees.EmployeePersonalDetails
{
    public class EmployeeDetailConfiguration : IEntityTypeConfiguration<EmployeePersonalDetail>
    {
        public void Configure(EntityTypeBuilder<EmployeePersonalDetail> builder)
        {
            builder.Property(bd => bd.EmployeeId);

        }
    }
}
