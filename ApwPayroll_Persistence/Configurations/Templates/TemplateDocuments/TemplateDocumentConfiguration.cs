using ApwPayroll_Domain.Entities.Notifications.NotificationListeners;
using Domain.Entities.Templates.TemplateDocuments;
using Domain.Models.Templates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApwPayroll_Persistence.Configurations.Templates.TemplateDocuments
{
    public class TemplateDocumentConfiguration : IEntityTypeConfiguration<TemplateDocument>
    {
        public void Configure(EntityTypeBuilder<TemplateDocument> builder)
        {
            builder.HasKey(td => new { td.DocumentId, td.TemplateId });

         
            builder.HasOne(td => td.Document)
                   .WithMany()
                   .HasForeignKey(td => td.DocumentId)
                   .IsRequired();

            builder.HasOne(td => td.Template)
                   .WithMany()
                   .HasForeignKey(td => td.TemplateId)
                   .IsRequired();
        }
    }
}
