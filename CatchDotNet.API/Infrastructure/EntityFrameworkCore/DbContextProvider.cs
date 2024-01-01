using Microsoft.EntityFrameworkCore;

namespace CatchDotNet.API.Infrastructure.EntityFrameworkCore
{
    public class DbContextProvider<TDbContext>(
        Func<TDbContext> dbContextFactory,
        IServiceProvider serviceProvider) :
        IDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {

        public IServiceProvider ServiceProvider { get; } = serviceProvider;


        // Current Db context
        private Func<TDbContext> _instanceFunc { get; set; } = dbContextFactory;
        private TDbContext DbContext { get; set; }
        public void Dispose()
        {
            GetDbContext().Dispose();
        }

        public TDbContext GetDbContext()
        {
            if (DbContext == null)
            {
                DbContext = _instanceFunc.Invoke();
            }

            return DbContext;
        }
    }
}
