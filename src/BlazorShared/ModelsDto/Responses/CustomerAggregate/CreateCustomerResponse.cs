using System;
using DDDCustomer.Domain.ModelsDto;

namespace BlazorShared.Models.Customer
{
    public class CreateCustomerResponse : BaseResponse
    {
        public CreateCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateCustomerResponse()
        {
        }

        public CustomerDto Customer { get; set; } = new();
    }
}