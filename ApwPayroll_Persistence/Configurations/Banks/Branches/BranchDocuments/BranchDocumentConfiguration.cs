using ApwPayroll_Domain.Entities.Banks.Branches.BranchDocuments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Persistence.Configurations.Banks.Branches.BranchDocuments
{
    public class BranchDocumentConfiguration : IEntityTypeConfiguration<BranchDocument>
    {
        public void Configure(EntityTypeBuilder<BranchDocument> builder)
        {
            builder.HasKey(bd => new { bd.BranchId, bd.DocumentId });

             
            builder.HasOne(bd => bd.Branch)
                   .WithMany()
                   .HasForeignKey(bd => bd.BranchId);

            builder.HasOne(bd => bd.Document)
                   .WithMany()
                   .HasForeignKey(bd => bd.DocumentId) ;

        
            builder.Property(bd => bd.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
