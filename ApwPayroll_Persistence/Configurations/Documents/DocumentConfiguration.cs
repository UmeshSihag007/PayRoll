using ApwPayroll_Domain.Entities.Documents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Documents
{
    public class DocumentConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.Property(x => x.Tittle).IsRequired(false);
            builder.HasOne(nl => nl.DocumentType)
                 .WithMany()
                 .HasForeignKey(nl => nl.TypeId)
                 .IsRequired();
        }
    }
}
