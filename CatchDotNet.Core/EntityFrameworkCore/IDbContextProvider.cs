using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.Core.EntityFrameworkCore
{
    public interface IDbContextProvider<TDbContext> : IDisposable
        where TDbContext : DbContext
    {
        TDbContext GetDbContext();
    }
}
