using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using BlazorShared.Models.Customer;
using DDDCustomer.Domain.Entities;
using DDDCustomer.Domain.Events;
using DDDCustomer.Domain.ModelsDto;
using dDDCustomerLib.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace DDDCustomer.Api.CustomerEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerRequest>.WithActionResult<
        CreateCustomerResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;

        private readonly IRepository<Customer> _repository;

        public Create(
            IRepository<Customer> repository,
            IMapper mapper,

            ILogger<Create> logger
        )
        {
            _mapper = mapper;

            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/customers")]
        [SwaggerOperation(
            Summary = "Creates a new Customer",
            Description = "Creates a new Customer",
            OperationId = "customers.create",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerResponse>> HandleAsync(
            CreateCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new CreateCustomerResponse(request.CorrelationId());
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
            await _repository.AddAsync(newCustomer);
            _logger.LogInformation(
                $"Customer created  with Id {newCustomer.CustomerId.ToString("D", CultureInfo.InvariantCulture)}");
            var dto = _mapper.Map<CustomerDto>(newCustomer);
            var customerCreatedEvent = new CustomerCreatedEvent(newCustomer, "Mongo-History");

            response.Customer = dto;
            return Ok(response);
        }
    }
}