using CatchDotNet.API.Domains;
using CatchDotNet.API.Infrastructure.Data;
using CatchDotNet.API.Infrastructure.EntityFrameworkCore;

namespace CatchDotNet.API.EntityFrameworkCore.Repositories
{
    public class CustomerEfCoreRepository : EfCoreRepository<ApplicationDbContext, Customer>, ICustomerRepository
    {
        public CustomerEfCoreRepository(IDbContextProvider<ApplicationDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }

        
    }
}
