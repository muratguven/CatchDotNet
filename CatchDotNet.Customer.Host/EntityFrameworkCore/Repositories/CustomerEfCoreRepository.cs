using CatchDotNet.Core.EntityFrameworkCore;
using CatchDotNet.Customer.Host.Domain;

namespace CatchDotNet.Customer.Host.EntityFrameworkCore.Repositories
{
    public class CustomerEfCoreRepository : EfCoreRepository<CustomerDbContext, Customers>, ICustomerRepository
    {
        public CustomerEfCoreRepository(IDbContextProvider<CustomerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }




    }
}
