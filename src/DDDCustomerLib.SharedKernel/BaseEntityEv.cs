using System.Collections.Generic;
using JetBrains.Annotations;

namespace dDDCustomerLib.SharedKernel
{
    public abstract class BaseEntityEv<TId>
    {
        [CanBeNull] public List<BaseDomainEvent> Events = new();
    }
}