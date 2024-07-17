using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Banks.Branches
{
    public class BranchConfigurations : IEntityTypeConfiguration<Branch>
    {
        
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
          builder .Property(x=>x.IsActive).HasDefaultValue(true);
        }
    }
}
