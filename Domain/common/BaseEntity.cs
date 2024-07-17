using System.ComponentModel.DataAnnotations.Schema;

namespace ApwPayroll_Domain.common
{
    public class BaseEntity
    {
        protected readonly List<BaseEvent> _domainEvents = new();
        public int Id { get; set; }
        [NotMapped]
        public IReadOnlyCollection<BaseEvent> Events => _domainEvents.AsReadOnly();
        public void AddDomainEvent(BaseEvent domain) => _domainEvents.Add(domain);
        public void RemoveDomainEvent(BaseEvent domain) => _domainEvents.Remove(domain);
        public void ClearDomainEvent() => _domainEvents.Clear();
    }
}
