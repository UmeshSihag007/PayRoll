using ApwPayroll_Domain.Entities.Notifications;
using ApwPayroll_Domain.Entities.Notifications.NotificationListeners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApwPayroll_Persistence.Configurations.Notifications.NotificationListeners
{
    public class NotificationListenerConfigurations : IEntityTypeConfiguration<NotificationListener>
    {
        public void Configure(EntityTypeBuilder<NotificationListener> builder)
        {
            builder.HasOne(nl => nl.Notification)
                          .WithMany()
                          .HasForeignKey(nl => nl.NotificationId)
                          .IsRequired();

            builder.HasOne(nl => nl.User)
                   .WithMany()
                   .HasForeignKey(nl => nl.UserId);

            builder.HasOne(nl => nl.Employee)
                   .WithMany()
                   .HasForeignKey(nl => nl.EmployeeId);

        }
    }
}
