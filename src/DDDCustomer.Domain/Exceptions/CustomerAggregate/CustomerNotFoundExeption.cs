using System;

namespace DDDCustomer.Domain.Exceptions
{
    public class CustomerNotFoundException : Exception
    {
        public CustomerNotFoundException(string message) : base(message)
        {
        }

        public CustomerNotFoundException(int customerId) : base($"No customer with id {customerId} found.")
        {
        }
    }
}