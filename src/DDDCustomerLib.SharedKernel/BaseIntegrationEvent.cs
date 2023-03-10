using MediatR;

namespace dDDCustomerLib.SharedKernel
{
    public abstract class BaseIntegrationEvent : OutBoxMessage, INotification
    {
    }
}