using System;
using System.ComponentModel.DataAnnotations;
using DDDCustomer.Domain.ModelsDto;

namespace BlazorShared.Models.Customer
{
    public class UpdateCustomerRequest : BaseRequest
    {
         public Guid CustomerId { get;  set; }

        public int CustomerNumber { get;  set; }

        public string FirstName { get;  set; }

        public string LastName { get;  set; }

        public decimal? CreditLimit { get;  set; }

        public string PhoneNumber { get;  set; }

        public DateTime DateCreated { get;  set; }

        public bool IsActive { get;  set; }

        public bool IsDeleted { get;  set; }

        public static UpdateCustomerRequest FromDto(CustomerDto customerDto)
        {
            return new UpdateCustomerRequest
            {
                CustomerId = customerDto.CustomerId,
                CustomerNumber = customerDto.CustomerNumber,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                CreditLimit = customerDto.CreditLimit,
                PhoneNumber = customerDto.PhoneNumber,
                DateCreated = customerDto.DateCreated,
                IsActive = customerDto.IsActive,
                IsDeleted = customerDto.IsDeleted
            };
        }
    }
}