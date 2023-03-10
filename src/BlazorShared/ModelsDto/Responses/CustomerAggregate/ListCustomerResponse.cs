using System;
using System.Collections.Generic;
using DDDCustomer.Domain.ModelsDto;

namespace BlazorShared.Models.Customer
{
    public class ListCustomerResponse : BaseResponse
    {
        public ListCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListCustomerResponse()
        {
        }

        public List<CustomerDto> Customers { get; set; } = new();
        public int Count { get; set; }
    }
}