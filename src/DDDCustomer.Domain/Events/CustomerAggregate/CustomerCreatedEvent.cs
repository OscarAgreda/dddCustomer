using System;
using DDDCustomer.Domain.Entities;
using dDDCustomerLib.SharedKernel;
using Newtonsoft.Json;

namespace DDDCustomer.Domain.Events
{
    public class CustomerCreatedEvent : BaseDomainEvent
    {
        public CustomerCreatedEvent(Customer customer, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Customer";
            Content = JsonConvert.SerializeObject(customer, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerCreated";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}