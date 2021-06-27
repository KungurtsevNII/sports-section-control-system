using System;
using System.Collections.Generic;

namespace Sscs.Domain.SharedKernel
{
    public abstract class Entity
    {
        private List<IDomainEvent> _domainEvents;
        
        public Guid Id { get; set; }
        
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents;
        
        public void AddDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents ??= new List<IDomainEvent>();
            _domainEvents.Add(eventItem);
        }
        
        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
    }
}