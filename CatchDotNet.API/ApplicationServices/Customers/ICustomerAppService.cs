using CatchDotNet.API.ApplicationServices.Customers.Dtos;
using CatchDotNet.Core.ApplicationService;

namespace CatchDotNet.API.ApplicationServices.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        Task<CreateCustomerDto> CreateCustomer(CreateCustomerDto customer);

        Task<List<CustomerDto>> GetAll();
    }
}
