namespace dDDCustomerLib.SharedKernel.Interfaces
{
    public interface IApplicationMessagePublisher
    {
        void Publish(BaseDomainEvent baseDomainEvent);
    }
}