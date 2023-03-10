using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

using DDDCustomer.Domain.Entities;
using DDDCustomer.Domain.ModelsDto;
using DDDCustomer.Domain.Specifications;
using DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR;
using dDDCustomerLib.SharedKernel.Interfaces;
using MediatR;

namespace DDDCustomer.Presentation.CustomerAggregate
{
    public class GetOneCustomerByIdHandler : IRequestHandler<GetOneCustomerByIdRequestM, GetOneCustomerByIdResponseM>
    {
        private readonly IRepository<Customer> _repository;
        private readonly IMapper _mapper;
        public GetOneCustomerByIdHandler(IRepository<Customer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetOneCustomerByIdResponseM> Handle(GetOneCustomerByIdRequestM request, CancellationToken cancellationToken)
        {
            var response = new GetOneCustomerByIdResponseM();

            var specification = new CustomerByIdWithIncludesSpec(request.CustomerId);
            var customer = await _repository.FirstOrDefaultAsync(specification, cancellationToken);

            response.Customer = _mapper.Map<CustomerDto>(customer);

            return response;
        }
    }


}
