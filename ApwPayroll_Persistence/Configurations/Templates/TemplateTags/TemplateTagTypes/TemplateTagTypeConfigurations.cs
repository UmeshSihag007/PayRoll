using ApwPayroll_Domain.Entities.Notifications.NotificationListeners;
using Domain.Entities.TemplateTags.TemplateTagTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Templates.TemplateTags.TemplateTagTypes
{
    public class TemplateTagTypeConfigurations : IEntityTypeConfiguration<TemplateTagType>
    {
        public void Configure(EntityTypeBuilder<TemplateTagType> builder)
        {
        builder.Property(x=>x.IsActive).HasDefaultValue(true);
        }
    }
}
