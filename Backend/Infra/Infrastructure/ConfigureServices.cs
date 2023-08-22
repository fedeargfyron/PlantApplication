using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Infrastructure.ExternalServices.ImageKit;
using Infrastructure.Options;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Infrastructure;

[ExcludeFromCodeCoverage]
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureConfiguration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ConnectionStringsOptions>(configuration.GetSection(ConnectionStringsOptions.ConnectionStringsName));
        services.Configure<ImageKitOptions>(configuration.GetSection(ImageKitOptions.ImageKitName));
        services.AddScoped<IPlantRepository, PlantRepository>();
        services.AddScoped<IExternalImageKitService, ExternalImageKitService>();
        services.AddDbContext<Context>();
        return services;
    }
}