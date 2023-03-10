using System;
using MediatR;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class GetOneCustomerByIdRequestM : IRequest<GetOneCustomerByIdResponseM>
    {
        public Guid CustomerId { get; set; }
    }
}