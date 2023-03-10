using System;

namespace DDDCustomer.Domain.Exceptions
{
    public class DuplicateCustomerException : ArgumentException
    {
        public DuplicateCustomerException(string message, string paramName) : base(message, paramName)
        {
        }
    }
}