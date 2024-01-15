using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.Core.EntityFrameworkCore
{
    public class DbContextProvider<TDbContext> :
        IDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {

        
        private IDbContextFactory<TDbContext> _factory {  get; set; }
        private TDbContext DbContext { get; set; }
        public DbContextProvider(IDbContextFactory<TDbContext> factory)
        {
            _factory = factory;
        }


        // Current Db context

        public void Dispose()
        {
            GetDbContext().Dispose();
        }

        public TDbContext GetDbContext()
        {
            if (DbContext == null)
            {
                DbContext = _factory.CreateDbContext();
            }
            Console.WriteLine(DbContext.ContextId);
            return DbContext;
        }
    }
}
