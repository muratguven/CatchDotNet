using AutoMapper;
using CatchDotNet.API.Domains;

namespace CatchDotNet.API.ApplicationService.Customers.Dtos
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile() 
        { 
            CreateMap<Customer, CreateCustomerDto>();

            CreateMap<Customer, CustomerDto>();
        }
    }
}
