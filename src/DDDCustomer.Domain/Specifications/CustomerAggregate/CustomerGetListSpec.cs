using Ardalis.Specification;
using DDDCustomer.Domain.Entities;

namespace DDDCustomer.Domain.Specifications
{
    public class CustomerGetListSpec : Specification<Customer>
    {
        public CustomerGetListSpec()
        {
            Query//.Where(customer => customer.IsDeleted != true)
                .OrderBy(customer => customer.FirstName)
                .AsNoTracking();
        }
    }
}