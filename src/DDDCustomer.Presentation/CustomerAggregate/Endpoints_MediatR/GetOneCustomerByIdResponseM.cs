using DDDCustomer.Domain.ModelsDto;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class GetOneCustomerByIdResponseM
    {
        public CustomerDto Customer { get; set; }
    }
}