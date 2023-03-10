using System;

namespace BlazorShared.Models.Customer
{
    public class CreateCustomerRequest : BaseRequest
    {
        public int CustomerNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? CreditLimit { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}