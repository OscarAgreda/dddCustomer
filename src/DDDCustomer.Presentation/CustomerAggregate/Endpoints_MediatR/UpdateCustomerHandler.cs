using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DDDCustomer.Domain.Entities;
using DDDCustomer.Domain.ModelsDto;
using dDDCustomerLib.SharedKernel.Interfaces;
using MediatR;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequestM, UpdateCustomerResponseM>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public UpdateCustomerHandler(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UpdateCustomerResponseM> Handle(UpdateCustomerRequestM request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(request.CustomerId, cancellationToken);

            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {request.CustomerId} not found.");
            }


            var cusToUpdate = _mapper.Map<Customer>(request);
            await _repository.UpdateAsync(cusToUpdate);
            var dto = _mapper.Map<CustomerDto>(cusToUpdate);

            var response = new UpdateCustomerResponseM
            {
                Customer =  dto
            };

            return response;
        }

        //public Task<UpdateCustomerResponseM> Handle(UpdateCustomerRequestM request, CancellationToken cancellationToken)
        //{
        //    return null;
        //}
    }
}