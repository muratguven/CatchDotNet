using CatchDotNet.API.Infrastructure.Data;
using CatchDotNet.API.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CatchDotNet.API.Infrastructure.DependencyInjection.Microsoft
{
    public static class EfCoreServiceCollectionExtension
    {
        public static IServiceCollection AddAppEfCore<TDbContext>(
          this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction
          )
          where TDbContext : DbContext
        {
            //services.AddDbContext<TDbContext>(optionsAction);
            services.AddDbContextFactory<TDbContext>(optionsAction);
            services.AddScoped(typeof(IUnitOfWork<>),typeof(UnitOfWork<>));
            services.AddScoped(typeof(IDbContextProvider<>),typeof(DbContextProvider<>));
            //services.AddTransient(typeof(IEfCoreRepository<>), typeof(EfCoreRepository<,>));
            ////services.AddTransient(typeof(IRepository<,>), typeof(EfCoreRepository<,,>));

            return services;
            
        }
    }
}
