using DDDCustomer.Domain.ModelsDto;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class CreateNewCustomerResponseM
    {
        public CustomerDto Customer { get; set; }
    }
}