using System;

namespace BlazorShared.Models
{
    public abstract class BaseMessage
    {
        protected Guid _correlationId = Guid.NewGuid();

        public Guid CorrelationId()
        {
            return _correlationId;
        }
    }
}