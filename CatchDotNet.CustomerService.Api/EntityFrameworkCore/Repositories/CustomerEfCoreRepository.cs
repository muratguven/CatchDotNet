using CatchDotNet.Core;
using CatchDotNet.Core.EntityFrameworkCore;
using CatchDotNet.CustomerService.Api.Exceptions.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CatchDotNet.CustomerService.Api
{
    public class CustomerEfCoreRepository : EfCoreRepository<CustomerDbContext, Customer>, ICustomerRepository
    {
        private readonly ILogger<CustomerEfCoreRepository> _logger;
        public CustomerEfCoreRepository(IDbContextProvider<CustomerDbContext> dbContextProvider, ILogger<CustomerEfCoreRepository> logger) : base(dbContextProvider)
        {
            _logger = logger;
        }

        public async Task CreateCustomerDetailAsync(Guid customerId, CustomerDetail detail)
        {
           var customer = await DbSet.FirstOrDefaultAsync(x=>x.Id == customerId);
            if (customer is null)
            {
                _logger.LogError($"CustomerService.CustomerEfCoreRepository Id : {customerId} not found!");
                throw new ApplicationException(CustomerExceptions.InvalidCustomer);
                
            }

            customer.AddDetail(detail);
           

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
