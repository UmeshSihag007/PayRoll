using ApwPayroll_Domain.Entities.Banks.Branches.BranchAddresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Banks.Branches.BranchAddresses
{
    public class BranchAddressConfiguration : IEntityTypeConfiguration<BranchAddress>
    {
        public void Configure(EntityTypeBuilder<BranchAddress> builder)
        {
            builder.HasOne(bd => bd.Branch)
            .WithMany()
            .HasForeignKey(bd => bd.BranchId);
        }
    }
}
