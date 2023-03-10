using System.Threading.Tasks;

namespace dDDCustomerLib.SharedKernel.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        Task HandleAsync(T args);
    }
}