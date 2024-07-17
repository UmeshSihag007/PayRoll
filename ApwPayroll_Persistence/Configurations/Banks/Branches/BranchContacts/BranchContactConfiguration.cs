using ApwPayroll_Domain.Entities.Banks.Branches.BranchContacts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Persistence.Configurations.Banks.Branches.BranchContacts
{
    public class BranchContactConfiguration : IEntityTypeConfiguration<BranchContact>
    {
        public void Configure(EntityTypeBuilder<BranchContact> builder)
        {
            builder.HasOne(bd => bd.Branch)
               .WithMany()
               .HasForeignKey(bd => bd.BranchId);
        }
    }
}
