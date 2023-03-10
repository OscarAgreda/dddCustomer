using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using BlazorShared.Models.Customer;
using DDDCustomer.Domain.Entities;
using DDDCustomer.Domain.ModelsDto;
using DDDCustomer.Domain.Specifications;
using dDDCustomerLib.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DDDCustomer.Api.CustomerEndpoints
{

    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdCustomerRequest>.WithActionResult<
        GetByIdCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;

        public GetByIdWithIncludes(
            IRepository<Customer> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customers/i/{CustomerId}")]
        [SwaggerOperation(
            Summary = "Get a Customer by Id With Includes",
            Description = "Gets a Customer by Id With Includes",
            OperationId = "customers.GetByIdWithIncludes",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerResponse(request.CorrelationId());
            var spec = new CustomerByIdWithIncludesSpec(request.CustomerId);
            var customer = await _repository.FirstOrDefaultAsync(spec);
            if (customer is null)
            {
                return NotFound();
            }

            response.Customer = _mapper.Map<CustomerDto>(customer);
            return Ok(response);
        }
    }
}