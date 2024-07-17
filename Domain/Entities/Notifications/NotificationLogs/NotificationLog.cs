using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Notifications;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApwPayroll_Domain.Entities.Notifications.NotificationLogs
{
    public class NotificationLog:BaseAuditEntity
    {
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime LogDate { get; set; }
    }
}
