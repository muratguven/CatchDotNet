namespace CatchDotNet.CustomerService.Api
{
    public static class CustomerEfCoreServiceCollectionExtension
    {
        public static IServiceCollection AddEfCore(this IServiceCollection services)
        {

            // Add Dependencies Here!

            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerEfCoreRepository));

            return services;
        }
    }
}
