using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Security;
using Infrastructure.ExternalServices.ChatGPT;
using Infrastructure.ExternalServices.GPT;
using Infrastructure.ExternalServices.ImageKit;
using Infrastructure.ExternalServices.PlantId;
using Infrastructure.ExternalServices.PlantNet;
using Infrastructure.ExternalServices.WeatherAPI;
using Infrastructure.Options;
using Infrastructure.Repositories;
using Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;
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
        services.Configure<PlantNetOptions>(configuration.GetSection(PlantNetOptions.PlantNetName));
        services.Configure<PlantIdOptions>(configuration.GetSection(PlantIdOptions.PlantIdName));
        services.Configure<WeatherAPIOptions>(configuration.GetSection(WeatherAPIOptions.WeatherAPIName));
        services.Configure<GPTOptions>(configuration.GetSection(GPTOptions.GPTName));
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        services.AddScoped<IPlantRepository, PlantRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IWateringDayRepository, WateringDayRepository>();
        services.AddScoped<IApplicationUser, ApplicationUser>();
        services.AddHttpContextAccessor();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IHealthAssesmentRepository, HealthAssesmentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPlantRiskRepository, PlantRiskRepository>();
        services.AddScoped<ILogRepository, LogRepository>();
        services.AddScoped<IExternalImageUploaderService, ExternalImageKitService>();
        services.AddScoped<IExternalWeatherService, ExternalWeatherAPIService>();
        services.AddScoped<IExternalPlantRiskGetterService, ExternalGPTPlantRiskGetterService>();
        services.AddScoped<IExternalRecognizerService, ExternalPlantNetService>();
        services.AddScoped<IExternalPlantInformationGetterService, ExternalGPTPlantInformationGetterService>();
        services.AddScoped<IExternalHealthAssesmentService, ExternalPlantIdService>();
        services.AddDbContext<Context>();
        return services;
    }
}