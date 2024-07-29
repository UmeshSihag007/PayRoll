using ApwPayroll_Domain.Entities.Banks.BankDetails;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Banks.BankDetails
{
    public class BankDetailConfiguration : IEntityTypeConfiguration<BankDetail>
    {

        public void Configure(EntityTypeBuilder<BankDetail> builder)
        {


            builder.HasOne(bd => bd.Employee)
                   .WithMany(x=>x.BankDetails)
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.HasOne(bd => bd.Bank)
                   .WithMany()
                   .HasForeignKey(bd => bd.BankId);

            //builder.hasone(bd => bd.bank)
            //       .withmany()
            //       .hasforeignkey(bd => bd.bankid);

            //   builder.Property(x => x.BankName).IsRequired();
        }
    }
}
