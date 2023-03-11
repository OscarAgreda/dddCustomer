using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DDDCustomer.Domain.Entities;
using dDDCustomerLib.SharedKernel.Interfaces;
using MediatR;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerRequestM, Unit>
    {
        private readonly IRepository<Customer> _repository;

        public DeleteCustomerHandler(IRepository<Customer> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCustomerRequestM request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.CustomerId, cancellationToken);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {request.CustomerId} not found.");
            }

            await _repository.DeleteAsync(customer, cancellationToken);

            return Unit.Value;
        }


    }
}