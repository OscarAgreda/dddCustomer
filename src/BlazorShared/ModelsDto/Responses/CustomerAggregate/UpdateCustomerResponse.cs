using System;
using DDDCustomer.Domain.ModelsDto;

namespace BlazorShared.Models.Customer
{
    public class UpdateCustomerResponse : BaseResponse
    {
        public UpdateCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateCustomerResponse()
        {
        }

        public CustomerDto Customer { get; set; } = new();
    }
}