using CatchDotNet.WebApi.Features.Cases.Domains;

namespace CatchDotNet.WebApi.EntityFrameworkCore;

public static class AppEfCoreServiceCollectionExtension
{
    public static IServiceCollection AddEfCore(this IServiceCollection services)
    {

        // Add Dependencies Here!

        services.AddScoped(typeof(ICustomerRepository), typeof(CustomerEfCoreRepository));
        services.AddScoped<ICategoryRepository, CategoryEfCoreRepository>();

        return services;
    }
}
