using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.Notifications.NotificationTypes;
using Domain.Models.Templates;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApwPayroll_Domain.Entities.Notifications
{
    public class Notification : BaseAuditEntity
    {
        public int TypeId { get; set; }
        public NotificationType NotificationType { get; set; }
         public int TemplateId { get; set; }
        public Template Template { get; set; }

        //  public List<NotificationListener> NotificationListener { get; set; } = new List<NotificationListener>();
    }
}
