using CatchDotNet.API.Domains;
using CatchDotNet.Core.EntityFrameworkCore;

namespace CatchDotNet.API.EntityFrameworkCore.Repositories
{
    public class CustomerEfCoreRepository : EfCoreRepository<ApplicationDbContext, Customer>, ICustomerRepository
    {
        public CustomerEfCoreRepository(IDbContextProvider<ApplicationDbContext> dbContextProvider) : base(dbContextProvider)
        {
            
        }

        
    }
}
