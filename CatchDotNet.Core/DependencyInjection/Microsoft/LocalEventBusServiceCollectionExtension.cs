using CatchDotNet.Core.Events.LocalEvents;
using Microsoft.Extensions.DependencyInjection;

namespace CatchDotNet.Core.DependencyInjection.Microsoft
{
    public static class LocalEventBusServiceCollectionExtension
    {
        public static IServiceCollection AddLocalEventBus(this IServiceCollection services)
        {
            services.AddTransient(typeof(ILocalEventBus<>), typeof(LocalEventBus<>));
            return services;
        }
    }
}
