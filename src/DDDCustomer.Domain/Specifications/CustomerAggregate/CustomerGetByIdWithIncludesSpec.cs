using System;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using DDDCustomer.Domain.Entities;

namespace DDDCustomer.Domain.Specifications
{
    public class CustomerByIdWithIncludesSpec : Specification<Customer>, ISingleResultSpecification
    {
        public CustomerByIdWithIncludesSpec(Guid customerId)
        {
            Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            Query.Where(customer => customer.CustomerId == customerId)
                .OrderBy(customer => customer.FirstName)
                .AsNoTracking();
        }
    }
}