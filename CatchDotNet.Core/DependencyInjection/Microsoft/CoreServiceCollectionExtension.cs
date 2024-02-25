using CatchDotNet.Core.ElasticSearch;
using CatchDotNet.Core.Exceptions;
using Microsoft.Extensions.DependencyInjection;

namespace CatchDotNet.Core.DependencyInjection.Microsoft
{
    public static class CoreServiceCollectionExtension
    {
        public static IServiceCollection AddCatchDotNetCore(this IServiceCollection services)
        {
            //Register all services here !
            services.AddTransient<GlobalExceptionMiddleware>();
          

            return services;
        }
    }
}
