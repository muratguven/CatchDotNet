using CatchDotNet.Core.Data;
using CatchDotNet.Core.EntityFrameworkCore;
using CatchDotNet.Core.EntityFrameworkCore.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace CatchDotNet.Core.DependencyInjection.Microsoft
{
    public static class EfCoreServiceCollectionExtension
    {
        public static IServiceCollection AddAppEfCoreModule<TDbContext>(
          this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction
          )
          where TDbContext : DbContext
        {
            //services.AddDbContext<TDbContext>(optionsAction);
            services.AddSingleton(typeof(SoftDeleteInterceptor));

            
            services.AddDbContextFactory<TDbContext>(optionsAction);
            services.AddScoped(typeof(IUnitOfWork<>),typeof(UnitOfWork<>));
            services.AddScoped(typeof(IDbContextProvider<>),typeof(DbContextProvider<>));
            //services.AddTransient(typeof(IEfCoreRepository<>), typeof(EfCoreRepository<,>));
            ////services.AddTransient(typeof(IRepository<,>), typeof(EfCoreRepository<,,>));

            return services;
            
        }
    }
}
