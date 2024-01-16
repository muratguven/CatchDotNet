using AutoMapper;
using CatchDotNet.Core.ApplicationService;

namespace CatchDotNet.Customer.Host.ApplicationServices.Customers
{
    public class CustomerApplicationService : ApplicationService, ICustomerAppService
    {
        public CustomerApplicationService(IMapper mapper) : base(mapper)
        {
        }

        
    }
}
