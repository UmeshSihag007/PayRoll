using ApwPayroll_Domain.common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApwPayroll_Domain.Entities.Notifications.NotificationTypes
{
    public class NotificationType:BaseAuditEntity
    {
  
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
