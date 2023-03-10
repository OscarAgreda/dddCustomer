using System;
using JetBrains.Annotations;

namespace dDDCustomerLib.SharedKernel
{
    public class OutBoxMessage
    {
        public Guid EventId { get; protected set; }
        public string EventType { get; set; }
        public string EntityNameType { get; set; }
        [CanBeNull] public string ActionOnMessageReceived { get; set; }
        [CanBeNull] public string Content { get; set; }
        public DateTime OccurredOnUtc { get; set; }
        [CanBeNull] public DateTime ProcessedOnUtc { get; set; }
    }
}