using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeChecklists
{
    public class EmployeeChecklistConfigurations : IEntityTypeConfiguration<EmployeeChecklist>
    {
        public void Configure(EntityTypeBuilder<EmployeeChecklist> builder)
        {
            builder.HasOne(bd => bd.Employee)
     .WithMany()
     .HasForeignKey(bd => bd.EmployeeId);

            builder.HasOne(bd => bd.Checklist)
   .WithMany()
   .HasForeignKey(bd => bd.CheckListId);
            builder.Property(x=>x.IsApproved).HasDefaultValue(false);
            builder.Property(x=>x.IsActive).HasDefaultValue(true);
        }
    }
}
