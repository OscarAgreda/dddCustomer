using System;
using MediatR;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class DeleteCustomerRequestM : IRequest<Unit>
    {
        public Guid CustomerId { get; set; }
    }
}