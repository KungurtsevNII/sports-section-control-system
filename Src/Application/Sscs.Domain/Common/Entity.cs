using System.Collections.Generic;

namespace Sscs.Domain.Common
{
    public abstract class Entity
    {
        private List<INotification> _domainEvents;
        
        public long Id { get; set; }
        
        public IReadOnlyList<INotification> DomainEvents => _domainEvents;
        
        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents ??= new List<INotification>();
            _domainEvents.Add(eventItem);
        }
        
        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
    }
}