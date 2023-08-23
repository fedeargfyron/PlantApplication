using Application.Handlers;
using Application.Handlers.RecognizePlantHandler;
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
        services.AddScoped<IUploadPlantService, UploadPlantService>();
        services.AddScoped<IPlantInformationGetterService, PlantInformationGetterService>();
        services.AddScoped<IPlantRecognizerService, PlantRecognizerService>();
        services.AddScoped<IRecognizePlantHandler, RecognizePlantHandler>();

        return services;
    }
}