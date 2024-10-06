using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CatchDotNet.Core.EndPoints;

public static class EndPointExtension
{
    /// <summary>
    /// Search endpoints from assembly and register its as transient
    /// </summary>
    /// <param name="services"></param>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IServiceCollection AddEndPoints(this IServiceCollection services, Assembly assembly)
    {
        ServiceDescriptor[] endPointServiceDescriptors = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false }  && type.IsAssignableTo(typeof(IEndPoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndPoint), type))
            .ToArray();
        services.TryAddEnumerable(endPointServiceDescriptors);
        return services;
    }


    /// <summary>
    /// Map endpoints automatically to app
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder MapEndPoints(this WebApplication app, RouteGroupBuilder? routeGroupBuilder = null)
    {
        IEnumerable<IEndPoint> endpoints = app.Services.GetRequiredService<IEnumerable<IEndPoint>>();
        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;
        foreach (IEndPoint endpoint in endpoints)
        {
            endpoint.MapEndPoints(builder);
        }
        
        return app;
    }
}