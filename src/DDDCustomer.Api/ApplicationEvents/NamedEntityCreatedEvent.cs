using dDDCustomerLib.SharedKernel.Interfaces;

namespace DDDCustomer.Api.ApplicationEvents
{
    public class NamedEntityCreatedEvent : IApplicationEvent
    {
        public NamedEntityCreatedEvent(NamedEntity entity, string eventType)
        {
            Entity = entity;
            EventType = eventType;
        }

        public NamedEntity Entity { get; set; }
        public string EventType { get; set; }
    }
}