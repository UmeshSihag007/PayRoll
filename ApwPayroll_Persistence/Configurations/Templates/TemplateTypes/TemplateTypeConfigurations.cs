using ApwPayroll_Domain.Entities.Notifications.NotificationListeners;
using Domain.Entities.Templates.TemplateTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Templates.TemplateTypes
{
    public class TemplateTypeConfigurations : IEntityTypeConfiguration<TemplateType>
    {
        public void Configure(EntityTypeBuilder<TemplateType> builder)
        {
          builder.Property(x=>x.IsActive).HasDefaultValue(true);    
        }
    }
}
