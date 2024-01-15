using CatchDotNet.API.Domains;
using CatchDotNet.API.EntityFrameworkCore.Repositories;

namespace CatchDotNet.API.EntityFrameworkCore
{
    public static class AppEfCoreServiceCollectionExtension
    {
        public static IServiceCollection AddEfCoreLayer(this IServiceCollection services)
        {
            services.AddTransient(typeof(ICustomerRepository), typeof(CustomerEfCoreRepository));
            return services;
        }
    }
}
