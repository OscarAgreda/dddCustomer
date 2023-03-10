using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using BlazorShared.Models.Customer;
using DDDCustomer.Domain.Entities;
using DDDCustomer.Domain.ModelsDto;
using dDDCustomerLib.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DDDCustomer.Api.CustomerEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerRequest>.WithActionResult<
        GetByIdCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;

        public GetById(
            IRepository<Customer> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customers/{CustomerId}")]
        [SwaggerOperation(
            Summary = "Get a Customer by Id",
            Description = "Gets a Customer by Id",
            OperationId = "customers.GetById",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerResponse(request.CorrelationId());
            var customer = await _repository.GetByIdAsync(request.CustomerId);
            if (customer is null)
            {
                return NotFound();
            }

            response.Customer = _mapper.Map<CustomerDto>(customer);
            return Ok(response);
        }
    }
}