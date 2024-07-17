using ApwPayroll_Domain.Entities.Notifications.NotificationListeners;
using Domain.Entities.Templates.TemplateBodies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Templates.TemplateBodies
{
    public class TemplateBodyConfiguration : IEntityTypeConfiguration<TemplateBody>
    {
        public void Configure(EntityTypeBuilder<TemplateBody> builder)
        {
            builder.HasOne(nl => nl.Template)
             .WithMany()
             .HasForeignKey(nl => nl.TemplateId)
             .IsRequired();
        }
    }
}
