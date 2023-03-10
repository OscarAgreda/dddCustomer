using System;
using DDDCustomer.Domain.ModelsDto;

namespace BlazorShared.Models.Customer
{
    public class GetByIdCustomerResponse : BaseResponse
    {
        public GetByIdCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerResponse()
        {
        }

        public CustomerDto Customer { get; set; } = new();
    }
}