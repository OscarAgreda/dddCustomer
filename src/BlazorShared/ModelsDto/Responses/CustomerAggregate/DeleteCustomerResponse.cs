using System;

namespace BlazorShared.Models.Customer
{
    public class DeleteCustomerResponse : BaseResponse
    {
        public DeleteCustomerResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerResponse()
        {
        }
    }
}