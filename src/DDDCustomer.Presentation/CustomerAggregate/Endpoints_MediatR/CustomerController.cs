using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DDDCustomer.Domain.ModelsDto;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DDDCustomer.Presentation.CustomerAggregate.Endpoints_MediatR
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get a Customer by Id",
            Description = "Gets a Customer by Id",
            OperationId = "customers.get",
            Tags = new[] { "CustomersEndpoints" })
        ]
        public async Task<ActionResult<CustomerDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var request = new GetOneCustomerByIdRequestM { CustomerId = id };
            var response = await _mediator.Send(request, cancellationToken);

            if (response.Customer == null)
            {
                return NotFound();
            }

            return Ok(response.Customer);
        }

        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new Customer",
            Description = "Creates a new Customer",
            OperationId = "customers.create",
            Tags = new[] { "CustomersEndpoints" })
        ]
        public async Task<ActionResult<CustomerDto>> Create(CreateNewCustomerRequestM request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = response.Customer.CustomerId }, response.Customer);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update an existing Customer",
            Description = "Updates an existing Customer",
            OperationId = "customers.update",
            Tags = new[] { "CustomersEndpoints" })
        ]
        public async Task<ActionResult<CustomerDto>> Update(Guid id, UpdateCustomerRequestM request, CancellationToken cancellationToken)
        {
            var existingCustomer = await _mediator.Send(new GetOneCustomerByIdRequestM { CustomerId = id }, cancellationToken);

            if (existingCustomer.Customer == null)
            {
                return NotFound();
            }

            request.CustomerId = id;
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response.Customer);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(
            Summary = "Delete a Customer",
            Description = "Deletes a Customer",
            OperationId = "customers.delete",
            Tags = new[] { "CustomersEndpoints" })
        ]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var existingCustomer = await _mediator.Send(new GetOneCustomerByIdRequestM { CustomerId = id }, cancellationToken);

            if (existingCustomer.Customer == null)
            {
                return NotFound();
            }

            await _mediator.Send(new DeleteCustomerRequestM { CustomerId = id }, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        // [HttpGet("api/customersm3")]
        [SwaggerOperation(
            Summary = "Get a list of Customers",
            Description = "Gets a list of Customers",
            OperationId = "customers.getList",
            Tags = new[] { "CustomersEndpoints" })
        ]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetListm(CancellationToken cancellationToken)
        {
            var request = new GetCustomersListRequestM();
            var response = await _mediator.Send(request, cancellationToken);

            return Ok(response.Customers);
        }
    }
}
