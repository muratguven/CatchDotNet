using CatchDotNet.API.Infrastructure.Domain;
using CatchDotNet.API.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.API.Infrastructure.Data
{
    public class UnitOfWork<TDbContext> : IUnitOfWork<TDbContext>  
        where TDbContext : DbContext
    {
        private IDbContextProvider<TDbContext> DbContextProvider { get; set; }
       
        public UnitOfWork(IDbContextProvider<TDbContext> dbContextProvider)
        {
            
            DbContextProvider = dbContextProvider;
        }

        public int Commit()
        {
            return DbContextProvider.GetDbContext().SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return DbContextProvider.GetDbContext().SaveChangesAsync();
        }

        public void Dispose()
        {
            DbContextProvider.GetDbContext().Dispose();
        }

      

        public void Rollback()
        {
            DbContextProvider.GetDbContext().Database.RollbackTransaction();
        }
    }
}
