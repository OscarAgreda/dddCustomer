using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using BlazorShared.Models.Customer;
using DDDCustomer.Domain.Entities;
using dDDCustomerLib.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DDDCustomer.Api.CustomerEndpoints
{

    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerRequest>.WithActionResult<
        DeleteCustomerResponse>
    {
        private readonly IRepository<Customer> _customerReadRepository;
        private readonly IMapper _mapper;

        private readonly IRepository<Customer> _repository;

        public Delete(
            IRepository<Customer> CustomerRepository,
            IRepository<Customer> CustomerReadRepository,

            IMapper mapper)
        {
            _repository = CustomerRepository;
            _customerReadRepository = CustomerReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customers/{CustomerId}")]
        [SwaggerOperation(
            Summary = "Deletes an Customer",
            Description = "Deletes an Customer",
            OperationId = "customers.delete",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerResponse>> HandleAsync(
            [FromRoute] DeleteCustomerRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerResponse(request.CorrelationId());
            var customer = await _customerReadRepository.GetByIdAsync(request.CustomerId);
            if (customer == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync(customer);
            return Ok(response);
        }
    }
}