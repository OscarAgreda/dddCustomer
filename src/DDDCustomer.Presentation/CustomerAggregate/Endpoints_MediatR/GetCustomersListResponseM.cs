using System.Collections.Generic;
using DDDCustomer.Domain.ModelsDto;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class GetCustomersListResponseM
    {
        public IEnumerable<CustomerDto> Customers { get; set; }
    }
}