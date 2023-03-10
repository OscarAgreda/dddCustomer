using System;
using DDDCustomer.Domain.Entities;
using dDDCustomerLib.SharedKernel;
using Newtonsoft.Json;

namespace DDDCustomer.Domain.Events
{
    public class CustomerDeletedEvent : BaseDomainEvent
    {
        public CustomerDeletedEvent(Customer customer, string action)
        {
            ActionOnMessageReceived = action;
            EntityNameType = "Customer";
            Content = JsonConvert.SerializeObject(customer, JsonSerializerSettingsSingleton.Instance);
            EventType = "CustomerDeleted";
            EventId = Guid.NewGuid();
            OccurredOnUtc = DateTime.UtcNow;
        }
    }
}