using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Employees.Checklists;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Employees.Checklists
{
    public class ChecklistConfiguration : IEntityTypeConfiguration<Checklist>
    {
        public void Configure(EntityTypeBuilder<Checklist> builder)
        {
            builder.HasOne(bd => bd.Parent)
     .WithMany()
     .HasForeignKey(bd => bd.ParentId);
        }
    }

}
