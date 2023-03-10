using System;
using DDDCustomer.Domain.Entities;
using dDDCustomerLib.SharedKernel;
using Newtonsoft.Json;

namespace DDDCustomer.Domain.Events
{
    public class CustomerUpdatedEvent : BaseDomainEvent
    {
        public CustomerUpdatedEvent(Customer customer, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Customer";
            Content = JsonConvert.SerializeObject(customer, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerUpdated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}