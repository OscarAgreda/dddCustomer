using MediatR;

namespace dDDCustomerLib.SharedKernel
{
    public abstract class BaseDomainEvent : OutBoxMessage, INotification
    {
    }
}