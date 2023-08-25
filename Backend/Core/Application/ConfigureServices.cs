using Application.Handlers;
using Application.Handlers.GenerateTokenHandler;
using Application.Handlers.RecognizePlantHandler;
using Application.Handlers.SavePlantHandler;
using Application.Services;
using Domain.Interfaces.Handlers;
using Domain.Interfaces.Services;
using Domain.Options;
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
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUploadPlantService, UploadPlantService>();
        services.AddScoped<IPlantInformationGetterService, PlantInformationGetterService>();
        services.AddScoped<IPlantRecognizerService, PlantRecognizerService>();
        services.AddScoped<IRecognizePlantHandler, RecognizePlantHandler>();
        services.AddSingleton<ITokenService, TokenService>();
        services.AddScoped<IGenerateTokenHandler, GenerateTokenHandler>();
        services.AddScoped<ISavePlantHandler, SavePlantHandler>();
        services.Configure<JWTOptions>(configuration.GetSection(JWTOptions.SectionName));

        return services;
    }
}