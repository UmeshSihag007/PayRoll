using ApwPayroll_Domain.Entities.Banks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Banks
{
    internal class BankConfigurations : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            // Configure foreign keys
            builder.HasOne(b => b.Employee)
                .WithMany()
                .HasForeignKey(b => b.EmployeeId);

            builder.HasOne(b => b.Branch)
                .WithMany()
                .HasForeignKey(b => b.BranchId);


            // Configure IsActive property
            builder.Property(b => b.IsBankAccountVerified)
                .IsRequired()
                .HasDefaultValue(false);
        }
    }
}
