using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.API.Infrastructure.EntityFrameworkCore
{
    public interface IDbContextProvider<TDbContext> : IDisposable
         where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}
