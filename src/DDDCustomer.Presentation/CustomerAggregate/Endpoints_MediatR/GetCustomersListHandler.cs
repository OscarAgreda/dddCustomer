using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using DDDCustomer.Domain.Entities;
using DDDCustomer.Domain.ModelsDto;
using DDDCustomer.Domain.Specifications;
using dDDCustomerLib.SharedKernel.Interfaces;
using MediatR;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    public class GetCustomersListHandler : IRequestHandler<GetCustomersListRequestM, GetCustomersListResponseM>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;

        public GetCustomersListHandler(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCustomersListResponseM> Handle(GetCustomersListRequestM request, CancellationToken cancellationToken)
        {
            var response = new GetCustomersListResponseM();


            var spec = new CustomerGetListSpec();
            var customers = await _repository.ListAsync(spec);


            response.Customers = _mapper.Map<IEnumerable<CustomerDto>>(customers);

            return response;
        }


    }
}
