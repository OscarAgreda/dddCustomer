using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace dDDCustomerLib.SharedKernel
{
    public abstract class EntityBase
    {
        private readonly List<BaseDomainEvent> _domainEvents = new();
        public int Id { get; set; }
        [NotMapped] public IEnumerable<BaseDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected void RegisterDomainEvent(BaseDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        internal void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}