using MediatR;

namespace ApwPayroll_Domain.common
{
    public abstract class BaseEvent : INotification
    {
        public DateTime DateOccurred { get; set; } = DateTime.UtcNow;
    }
}
