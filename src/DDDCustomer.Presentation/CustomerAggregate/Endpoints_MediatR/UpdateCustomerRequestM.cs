using System;
using MediatR;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class UpdateCustomerRequestM : IRequest<UpdateCustomerResponseM>
    {
        public Guid CustomerId { get; set; }

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