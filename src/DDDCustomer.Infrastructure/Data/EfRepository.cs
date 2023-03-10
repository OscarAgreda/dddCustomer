using Ardalis.Specification.EntityFrameworkCore;
using dDDCustomerLib.SharedKernel.Interfaces;

namespace DDDCustomer.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
    {
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}