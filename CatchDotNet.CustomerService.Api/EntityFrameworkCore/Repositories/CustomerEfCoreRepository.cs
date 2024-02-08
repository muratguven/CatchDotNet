using CatchDotNet.Core.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.CustomerService.Api
{
    public class CustomerEfCoreRepository : EfCoreRepository<CustomerDbContext, Customer>, ICustomerRepository
    {
        public CustomerEfCoreRepository(IDbContextProvider<CustomerDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

      

        public Task<List<Customer>> GetPagedListAsync(int skip, int pageSize)
        {
            return DbSet
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
        }

        public Task<int> GetTotalCountAsync()
        {
            return DbSet.CountAsync();
        }
    }
}
