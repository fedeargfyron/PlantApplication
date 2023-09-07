using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Repositories;
using Infrastructure.ExternalServices.ChatGPT;
using Infrastructure.ExternalServices.ImageKit;
using Infrastructure.ExternalServices.PlantNet;
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
        services.Configure<GPTOptions>(configuration.GetSection(GPTOptions.GPTName));
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
        services.AddScoped<IPlantRepository, PlantRepository>();
        services.AddScoped<IPermissionRepository, PermissionRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IExternalImageUploaderService, ExternalImageKitService>();
        services.AddScoped<IExternalRecognizerService, ExternalPlantNetService>();
        services.AddScoped<IExternalPlantInformationGetterService, ExternalGPTService>();
        services.AddDbContext<Context>();
        return services;
    }
}