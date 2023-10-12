using Application.Handlers.GenerateTokenHandler;
using Application.Handlers.Groups.AddGroupHandler;
using Application.Handlers.Groups.GetAllGroupsHandler;
using Application.Handlers.Groups.GetGroupByIdHandler;
using Application.Handlers.Groups.RemoveGroupHandler;
using Application.Handlers.Groups.UpdateGroupHandler;
using Application.Handlers.Permissions.GetAllPermissionsHandler;
using Application.Handlers.Plants;
using Application.Handlers.Plants.HealthAssesmentHandler;
using Application.Handlers.Plants.RecognizePlantHandler;
using Application.Handlers.Plants.SavePlantHandler;
using Application.Handlers.RiskAlerts.GetRiskAlertsHandler;
using Application.Handlers.Users.AddUserHandler;
using Application.Handlers.Users.GetAllUsersHandler;
using Application.Handlers.Users.GetUserByIdHandler;
using Application.Handlers.Users.RemoveUserHandler;
using Application.Handlers.Users.UpdateUserHandler;
using Application.Handlers.WateringCalendar.GetWateringDaysFromUserHandler;
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
        services.AddScoped<IUpdateUserHandler, UpdateUserHandler>();
        services.AddScoped<IRemoveUserHandler, RemoveUserHandler>();
        services.AddScoped<IGetUserByIdHandler, GetUserByIdHandler>();
        services.AddScoped<IGetAllUsersHandler, GetAllUsersHandler>();
        services.AddScoped<IAddUserHandler, AddUserHandler>();
        services.AddScoped<IUpdateGroupHandler, UpdateGroupHandler>();
        services.AddScoped<IRemoveGroupHandler, RemoveGroupHandler>();
        services.AddScoped<IGetAllPermissionsHandler, GetAllPermissionsHandler>();
        services.AddScoped<IHealthAssesmentHandler, HealthAssesmentHandler>();
        services.AddScoped<IHealthAssesmentService, HealthAssesmentService>();
        services.AddScoped<IWeatherService, WeatherService>();
        services.AddScoped<IWateringCalendarService, WateringCalendarService>();
        services.AddScoped<IGetWateringDaysFromUserHandler, GetWateringDaysFromUserHandler>();
        services.AddScoped<IGetGroupByIdHandler, GetGroupByIdHandler>();
        services.AddScoped<IGetAllGroupsHandler, GetAllGroupsHandler>();
        services.AddScoped<IAddGroupHandler, AddGroupHandler>();
        services.AddScoped<IPlantService, PlantService>();
        services.AddScoped<IPlantRisksService, PlantRisksService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IUploadPlantService, UploadPlantService>();
        services.AddScoped<IPlantInformationGetterService, PlantInformationGetterService>();
        services.AddScoped<IGetRiskAlertsHandler, GetRiskAlertsHandler>();
        services.AddScoped<IPlantRecognizerService, PlantRecognizerService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IRecognizePlantHandler, RecognizePlantHandler>();
        services.AddSingleton<ITokenService, TokenService>();
        services.AddScoped<IGenerateTokenHandler, GenerateTokenHandler>();
        services.AddScoped<ISavePlantHandler, SavePlantHandler>();
        services.Configure<JWTOptions>(configuration.GetSection(JWTOptions.SectionName));

        return services;
    }
}