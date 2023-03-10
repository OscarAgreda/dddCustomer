using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DDDCustomer.Domain.Entities;
using DDDCustomer.Domain.ModelsDto;
using dDDCustomerLib.SharedKernel.Interfaces;
using MediatR;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class CreateNewCustomerHandler : IRequestHandler<CreateNewCustomerRequestM, CreateNewCustomerResponseM>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public CreateNewCustomerHandler(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreateNewCustomerResponseM> Handle(CreateNewCustomerRequestM request, CancellationToken cancellationToken)
        {
            var newCustomer = new Customer(
                Guid.NewGuid(),
                request.CustomerNumber,
                request.FirstName,
                request.LastName,
                request.CreditLimit,
                request.PhoneNumber,
                request.DateCreated,
                request.IsActive,
                request.IsDeleted
            );

            await _repository.AddAsync(newCustomer, cancellationToken);

            var response = new CreateNewCustomerResponseM
            {
                Customer = _mapper.Map<CustomerDto>(newCustomer)
            };

            return response;
        }
    }
}