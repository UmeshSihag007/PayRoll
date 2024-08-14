using ApwPayroll_Domain.Entities.Documents;
using ApwPayroll_Domain.Entities.Employees.EmployeeDocumentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Domain.Entities.Employees.EmployeeDocuments
{
    public class EmployeeDocumentConfiguration : IEntityTypeConfiguration<EmployeeDocument>
    {
        public void Configure(EntityTypeBuilder<EmployeeDocument> builder)
        {
            builder.HasKey(bd => new { bd.EmployeeId, bd.DocumentId });
             
            builder.HasOne(bd => bd.Employee)
                   .WithMany(e => e.EmployeeDocuments)  
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.HasOne(bd => bd.Document)
                   .WithMany(d => d.EmployeeDocuments) 
                   .HasForeignKey(bd => bd.DocumentId);

            builder.HasOne(bd => bd.EmployeeDocumentType)
                   .WithMany()  
                   .HasForeignKey(bd => bd.EmployeeDocumentTypeId);

            builder.Property(bd => bd.IsActive).HasDefaultValue(true);

            builder.HasIndex(x => new { x.EmployeeId, x.DocumentId });
        }
    }
}
