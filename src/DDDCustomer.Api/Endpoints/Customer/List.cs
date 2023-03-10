using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListCustomerRequest>.WithActionResult<ListCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;

        public List(
            IRepository<Customer> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customers")]
        [SwaggerOperation(
            Summary = "List Customers",
            Description = "List Customers",
            OperationId = "customers.List",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerResponse>> HandleAsync(
            [FromQuery] ListCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerResponse(request.CorrelationId());
            var spec = new CustomerGetListSpec();
            var customers = await _repository.ListAsync(spec);
            if (customers is null)
            {
                return NotFound();
            }

            response.Customers = _mapper.Map<List<CustomerDto>>(customers);
            response.Count = response.Customers.Count;
            return Ok(response);
        }
    }
}