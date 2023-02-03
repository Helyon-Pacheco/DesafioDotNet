using DesafioDotNet.Domain.Interfaces;
using DesafioDotNet.Domain.Notifications;
using DesafioDotNet.Infra.Data.Context;
using DesafioDotNet.Infra.Data.Interfaces;
using DesafioDotNet.Infra.Data.Repository;
using DesafioDotNet.Service.Interfaces;
using DesafioDotNet.Service.Services;

namespace DesafioDotNet.Application.Configuration;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<DesafioDotNetDbContext>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<INotifier, Notifier>();


        return services;
    }
}
