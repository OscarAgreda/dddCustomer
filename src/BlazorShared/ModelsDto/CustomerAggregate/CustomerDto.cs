using System;
using System.ComponentModel.DataAnnotations;
using Ardalis.GuardClauses;

namespace DDDCustomer.Domain.ModelsDto
{
    public class CustomerDto
    {
        public CustomerDto() { }

        public CustomerDto(
            Guid customerId,
            int customerNumber,
            string firstName,
            string lastName,
            decimal? creditLimit,
            string phoneNumber,
            DateTime dateCreated,
            bool isActive,
            bool isDeleted)
        {
            CustomerId = Guard.Against.NullOrEmpty(customerId, nameof(customerId));
            CustomerNumber = Guard.Against.NegativeOrZero(customerNumber, nameof(customerNumber));
            FirstName = Guard.Against.NullOrWhiteSpace(firstName, nameof(firstName));
            LastName = Guard.Against.NullOrWhiteSpace(lastName, nameof(lastName));
            CreditLimit = creditLimit;
            PhoneNumber = Guard.Against.NullOrWhiteSpace(phoneNumber, nameof(phoneNumber));
            DateCreated = Guard.Against.OutOfSQLDateRange(dateCreated, nameof(dateCreated));
            IsActive = Guard.Against.Null(isActive, nameof(isActive));
            IsDeleted = Guard.Against.Null(isDeleted, nameof(isDeleted));
        }

        public Guid CustomerId { get; private set; }

        [Required(ErrorMessage = "Customer Number is required")]
        public int CustomerNumber { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(250)]
        public string LastName { get; set; }

        public decimal? CreditLimit { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Date Created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Is Active is required")]
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Is Deleted is required")]
        public bool IsDeleted { get; set; }
    }
}