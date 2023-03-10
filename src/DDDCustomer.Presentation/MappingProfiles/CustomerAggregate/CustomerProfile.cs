using AutoMapper;
using BlazorShared.Models.Customer;
using DDDCustomer.Domain.Entities;
using DDDCustomer.Domain.ModelsDto;

namespace DDDCustomer.Api.MappingProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<CreateCustomerRequest, Customer>();
            CreateMap<UpdateCustomerRequest, Customer>();
            CreateMap<DeleteCustomerRequest, Customer>();
        }
    }
}