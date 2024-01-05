using CatchDotNet.API.ApplicationService.Customers.Dtos;
using CatchDotNet.API.Infrastructure.ApplicationService;

namespace CatchDotNet.API.ApplicationService.Customers
{
    public interface ICustomerAppService : IAppService
    {
        Task<CreateCustomerDto> CreateCustomer(CreateCustomerDto customer);

        Task<List<CustomerDto>> GetAll();
    }
}
