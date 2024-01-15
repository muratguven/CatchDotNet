using AutoMapper;
using CatchDotNet.API.Domains;

namespace CatchDotNet.API.ApplicationServices.Customers.Dtos
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
