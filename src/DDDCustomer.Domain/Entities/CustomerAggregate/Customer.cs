using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Ardalis.GuardClauses;
using dDDCustomerLib.SharedKernel;
using dDDCustomerLib.SharedKernel.Interfaces;

namespace DDDCustomer.Domain.Entities
{
    public class Customer : BaseEntityEv<Guid>, IAggregateRoot
    {
        private Customer() { }

        [SetsRequiredMembers]
        public Customer(
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

        [Key] public Guid CustomerId { get; private set; }

        public int CustomerNumber { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public decimal? CreditLimit { get; private set; }

        public string PhoneNumber { get; private set; }

        public DateTime DateCreated { get; private set; }

        public bool IsActive { get; private set; }

        public bool IsDeleted { get; private set; }

        public void SetFirstName(string firstName)
        {
            FirstName = Guard.Against.NullOrEmpty(firstName, nameof(firstName));
        }

        public void SetLastName(string lastName)
        {
            LastName = Guard.Against.NullOrEmpty(lastName, nameof(lastName));
        }

        public void SetPhoneNumber(string phoneNumber)
        {
            PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber, nameof(phoneNumber));
        }
    }
}