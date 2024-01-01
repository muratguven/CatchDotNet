using CatchDotNet.API.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.API.Infrastructure.Data
{
    public interface IUnitOfWork<TDbContext> :IDisposable
       where TDbContext:DbContext
    {
        int Commit();
        Task<int> CommitAsync();
        void Rollback();
        
    }
}
