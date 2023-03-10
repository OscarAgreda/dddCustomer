using Ardalis.Specification;

namespace dDDCustomerLib.SharedKernel.Interfaces
{
    public interface IReadWithoutCacheRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
    {
    }
}