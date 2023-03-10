using System;

namespace BlazorShared.Models.Customer
{
    public class GetByIdCustomerRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
    }
}