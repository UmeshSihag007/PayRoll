using ApwPayroll_Domain.common;
using ApwPayroll_Domain.common.Enums.FormatTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Domain.Entities.Banks.Branches.BranchNumberFormats
{
    public class BranchNumberFormatConfiguration : IEntityTypeConfiguration<BranchNumberFormat>
    {
       

        public void Configure(EntityTypeBuilder<BranchNumberFormat> builder)
        {
           builder.HasKey(x => x.Id);   

            builder.HasOne(bd => bd.Branch)
                   .WithMany()
                   .HasForeignKey(bd => bd.BranchId);


        }
    }
}
