using ApwPayroll_Domain.Entities.Employees.EmployeeAddresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Employees.EmployeeAddresses
{
    public class EmployeeAddressConfiguration : IEntityTypeConfiguration<EmployeeAddress>
    {


        public void Configure(EntityTypeBuilder<EmployeeAddress> builder)
        {
            builder.HasOne(bd => bd.AddressType)
       .WithMany()
       .HasForeignKey(bd => bd.AddressTypeId);
            builder.HasOne(bd => bd.Employee)
   .WithMany(x => x.EmployeeAddresses)
   .HasForeignKey(bd => bd.EmployeeId);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
