using ApwPayroll_Domain.Entities.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Notifications
{
    public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasOne(nl => nl.NotificationType)
                    .WithMany()
                    .HasForeignKey(nl => nl.TypeId)
                    .IsRequired();

            builder.HasOne(nl => nl.Template)
                 .WithMany()
                 .HasForeignKey(nl => nl.TemplateId);
        }
    }
}
