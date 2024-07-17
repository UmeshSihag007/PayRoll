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

            // Define the relationships explicitly
            builder.HasOne(bd => bd.Employee)
                   .WithMany(e => e.EmployeeDocuments) // Assuming you have a navigation property in Employee class
                   .HasForeignKey(bd => bd.EmployeeId);

            builder.HasOne(bd => bd.Document)
                   .WithMany(d => d.EmployeeDocuments) // Assuming you have a navigation property in Document class
                   .HasForeignKey(bd => bd.DocumentId);

            builder.HasOne(bd => bd.EmployeeDocumentType)
                   .WithMany() // Assuming you have a navigation property in EmployeeDocumentType class
                   .HasForeignKey(bd => bd.EmployeeDocumentTypeId);

            builder.Property(bd => bd.IsActive).HasDefaultValue(true);

            builder.HasIndex(x => new { x.EmployeeId, x.DocumentId });
        }
    }
}
