namespace CatchDotNet.WebApi;

public static class AppEfCoreServiceCollectionExtension
{
    public static IServiceCollection AddEfCore(this IServiceCollection services)
    {

        // Add Dependencies Here!

        services.AddScoped(typeof(ICustomerRepository), typeof(CustomerEfCoreRepository));

        return services;
    }
}
