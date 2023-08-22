using Application.Handlers;
using Application.Services;
using Domain.Interfaces.Handlers;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ConfigureServices
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IPlantHandler, PlantHandler>();
        services.AddScoped<IPlantService, PlantService>();
        services.AddScoped<IImageKitService, ImageKitService>();
        services.AddScoped<IImageKitHandler, ImageKitHandler>();

        return services;
    }
}