using ApwPayroll_Domain.Entities.Notifications.NotificationLogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Notifications.NotificationLogs
{
    public class NotificationLogConfigurations : IEntityTypeConfiguration<NotificationLog>
    {
        public void Configure(EntityTypeBuilder<NotificationLog> builder)
        {
            builder.HasOne(nl => nl.Notification)
                   .WithMany()
                   .HasForeignKey(nl => nl.NotificationId)
                   .IsRequired() ;
        }
    }
}
