using System;

namespace BlazorShared.Models.Customer
{
    public class DeleteCustomerRequest : BaseRequest
    {
        public Guid CustomerId { get; set; }
    }
}