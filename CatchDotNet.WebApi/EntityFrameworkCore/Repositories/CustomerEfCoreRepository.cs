using CatchDotNet.Core.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.WebApi
{
    public class CustomerEfCoreRepository : EfCoreRepository<CatchDbContext, Customer>, ICustomerRepository
    {
        private readonly ILogger<CustomerEfCoreRepository> _logger;
        public CustomerEfCoreRepository(IDbContextProvider<CatchDbContext> dbContextProvider, ILogger<CustomerEfCoreRepository> logger) : base(dbContextProvider)
        {
            _logger = logger;
        }

        public async Task CreateCustomerDetailAsync(Guid customerId, CustomerDetail detail, CancellationToken cancellationToken)
        {
           var customer = await DbSet.FirstOrDefaultAsync(x=>x.Id == customerId,cancellationToken);
            if (customer is null)
            {
                _logger.LogError($"CustomerService.CustomerEfCoreRepository Id : {customerId} not found!");
                throw new ApplicationException(CustomerExceptions.InvalidCustomer);
                
            }

            customer.AddDetail(detail);
           

        }

        public Task<List<Customer>> GetPagedListAsync(int skip, int pageSize, CancellationToken cancellationToken)
        {
            return DbSet
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync(cancellationToken);
        }

        public Task<int> GetTotalCountAsync(CancellationToken cancellationToken)
        {
            return DbSet.CountAsync(cancellationToken);
        }

        public Task<bool> HasDetail(Guid customerId, string key, CancellationToken cancellationToken)
        {
            return DbContext.Set<CustomerDetail>()
                .AnyAsync(x=>x.CustomerId == customerId && x.DetailKey.Contains(key),cancellationToken);
        }
    }
}
