using ApwPayroll_Domain.Entities.Banks.Branches.BranchDocuments.BranchDocumentTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Persistence.Configurations.Banks.Branches.BranchDocuments.BranchDocumentTypes
{
    public class BranchDocumentTypeConfiguration : IEntityTypeConfiguration<BranchDocumentType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<BranchDocumentType> builder)
        {
           builder.Property(x=>x.IsActive).HasDefaultValue(true);   
        }
    }
}
