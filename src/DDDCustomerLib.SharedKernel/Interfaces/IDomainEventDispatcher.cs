using System.Collections.Generic;
using System.Threading.Tasks;

namespace dDDCustomerLib.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task DispatchAndClearEvents(IEnumerable<EntityBase> entitiesWithEvents);
    }
}