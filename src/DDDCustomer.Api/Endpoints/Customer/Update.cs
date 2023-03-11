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

namespace BusinessManagement.Api.CustomerEndpoints
{
    /// <summary>
    ///     This is an example of an API endpoint that handles a PUT request to update a customer.
    ///     The endpoint uses the Update class that inherits from EndpointBaseAsync and specifies
    ///     the request and response types as UpdateCustomerRequest and UpdateCustomerResponse,
    ///     respectively. The endpoint takes in two dependencies in its constructor,
    ///     an IRepository
    ///     <Customer>
    ///         and an IMapper. The IRepository
    ///         <Customer>
    ///             is used to interact
    ///             with the data store and perform operations such as updating a customer. The IMapper is
    ///             used to map between the request and response models and the domain models.
    ///             The HandleAsync method is overridden and handles the PUT request by first mapping the
    ///             request model to the domain model using the IMapper. It then calls the UpdateAsync
    ///             method on the IRepository to update the customer in the data store. Finally, it maps
    ///             the updated customer to the response model and returns an Ok result with the response model.
    ///             The endpoint also has a Swagger annotation that provides metadata for the endpoint such
    ///             as a summary, description, and tags.
    /// </summary>
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerRequest>.WithActionResult<UpdateCustomerResponse>
    {
        private readonly IMapper _mapper;

        private readonly IRepository<Customer> _repository;

        public Update(
            IRepository<Customer> repository,

            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customers")]
        [SwaggerOperation(
            Summary = "Updates a Customer",
            Description = "Updates a Customer",
            OperationId = "customers.update",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerResponse>> HandleAsync(UpdateCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerResponse(request.CorrelationId());


            var cusToUpdate = _mapper.Map<Customer>(request);
            await _repository.UpdateAsync(cusToUpdate);


            var dto = _mapper.Map<CustomerDto>(cusToUpdate);



            response.Customer = dto;
            return Ok(response);
        }
    }
}