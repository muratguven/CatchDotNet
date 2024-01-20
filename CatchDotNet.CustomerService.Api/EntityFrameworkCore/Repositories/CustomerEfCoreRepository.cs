using CatchDotNet.Core.EntityFrameworkCore;

namespace CatchDotNet.CustomerService.Api
{
    public class CustomerEfCoreRepository : EfCoreRepository<CustomerDbContext, Customer>, ICustomerRepository
    {
        public CustomerEfCoreRepository(IDbContextProvider<CustomerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }




    }
}
