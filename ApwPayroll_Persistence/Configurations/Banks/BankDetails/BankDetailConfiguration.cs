using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.AccountType;
using ApwPayroll_Domain.Entities.Banks.BankDetails;
using ApwPayroll_Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Banks.BankDetails
{
    public class BankDetailConfiguration :  IEntityTypeConfiguration<BankDetail>
    { 

        public void Configure(EntityTypeBuilder<BankDetail> builder)
        {
            

            builder.HasOne(bd => bd.Employee)
                   .WithMany()
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.Property(x => x.BankName).IsRequired();
        }
    }
}
