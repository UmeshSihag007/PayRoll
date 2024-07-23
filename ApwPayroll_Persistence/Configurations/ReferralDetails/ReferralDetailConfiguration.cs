using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Domain.Entities.ReferralDetails
{
    public class ReferralDetailConfiguration : IEntityTypeConfiguration<ReferralDetail>
    {
        public void Configure(EntityTypeBuilder<ReferralDetail> builder)
        {
            builder.HasOne(e => e.Employee)
               .WithMany(x=>x.ReferralDetail)
               .HasForeignKey(e => e.EmployeeId);
        }
    }
}
