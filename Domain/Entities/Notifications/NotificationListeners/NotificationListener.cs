using ApwPayroll_Domain.common;
using ApwPayroll_Domain.Entities.AspUsers;
using ApwPayroll_Domain.Entities.Employees;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApwPayroll_Domain.Entities.Notifications.NotificationListeners
{
    public class NotificationListener : BaseAuditEntity
    {
       
        public int NotificationId { get; set; }
        public Notification Notification { get; set; }
        public string? UserId { get; set; }
        public AspUser? User { get; set; } 
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public bool IsSended { get; set; } = false;
        public bool IsSeen { get; set; } = false;
        public bool IsRead { get; set; } = false;
        public bool IsActive { get; set; } = false;

        public NotificationListener()
        {

        }
        public NotificationListener(int notificationId, string userId, bool isSended, bool isSeen, bool isRead, bool isActive)
        {
            NotificationId = notificationId;
            UserId = userId;
            IsSended = isSended;
            IsSeen = isSeen;
            IsRead = isRead;
            IsActive = isActive;
        }

    }
}
