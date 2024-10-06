using CatchDotNet.Core.EntityFrameworkCore;
using CatchDotNet.WebApi.Features.Cases.Domains;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.WebApi;

public class CategoryEfCoreRepository : EfCoreRepository<CatchDbContext, Category>, ICategoryRepository
{
    public CategoryEfCoreRepository(IDbContextProvider<CatchDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public Task<bool> ExistsAsync(string name)
    {
        return DbSet.AnyAsync(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
    }
}