using Application.Handlers.GenerateTokenHandler;
using Application.Handlers.Groups.AddGroupHandler;
using Application.Handlers.Groups.GetAllGroupsHandler;
using Application.Handlers.Groups.GetGroupByIdHandler;
using Application.Handlers.Groups.RemoveGroupHandler;
using Application.Handlers.Groups.UpdateGroupHandler;
using Application.Handlers.Metrics.CreatedUsersAmountHandler;
using Application.Handlers.Metrics.HealthyPlantsAmountHandler;
using Application.Handlers.Metrics.LoginAmountHandler;
using Application.Handlers.Metrics.ScansAmountHandler;
using Application.Handlers.Permissions.GetAllPermissionsHandler;
using Application.Handlers.Plants;
using Application.Handlers.Plants.GetHealthAssesmentsByIdHandler;
using Application.Handlers.Plants.GetHealthAssesmentsHandler;
using Application.Handlers.Plants.HealthAssesmentHandler;
using Application.Handlers.Plants.RecognizePlantHandler;
using Application.Handlers.Plants.SavePlantHandler;
using Application.Handlers.RiskAlerts.GetRiskAlertsHandler;
using Application.Handlers.Users.AddUserHandler;
using Application.Handlers.Users.GetAllUsersHandler;
using Application.Handlers.Users.GetUserByIdHandler;
using Application.Handlers.Users.RecoverUserPasswordHandler;
using Application.Handlers.Users.RegisterUserHandler;
using Application.Handlers.Users.RemoveUserHandler;
using Application.Handlers.Users.ResetUserPaswordHandler;
using Application.Handlers.Users.UpdateUserHandler;
using Application.Handlers.WateringCalendar.GetWateringDaysFromUserHandler;
using Application.Services;
using Application.Strategies.MetricsGetter;
using Domain.Interfaces.Handlers;
using Domain.Interfaces.Services;
using Domain.Interfaces.Strategies.MetricsGetter;
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
        services.AddScoped<IGetHealthAssesmentsHandler, GetHealthAssesmentsHandler>();
        services.AddScoped<IGetHealthAssesmentByIdHandler, GetHealthAssesmentByIdHandler>();
        services.AddScoped<IScansAmountHandler, ScansAmountHandler>();
        services.AddScoped<IHealthyPlantsAmountHandler, HealthyPlantsAmountHandler>();
        services.AddScoped<ICreatedUsersAmountHandler, CreatedUsersAmountHandler>();
        services.AddScoped<ILoginAmountHandler, LoginAmountHandler>();
        services.AddScoped<IRegisterUserHandler, RegisterUserHandler>();
        services.AddScoped<IRecoverUserPasswordHandler, RecoverUserPasswordHandler>();
        services.AddScoped<IChangeUserPaswordHandler, ChangeUserPaswordHandler>();
        services.AddScoped<IGetGroupByIdHandler, GetGroupByIdHandler>();
        services.AddScoped<IGetAllGroupsHandler, GetAllGroupsHandler>();
        services.AddScoped<IAddGroupHandler, AddGroupHandler>();
        services.AddScoped<IPlantService, PlantService>();
        services.AddScoped<IMetricsGetterFactory, MetricsGetterFactory>();
        services.AddScoped<IPlantRisksService, PlantRisksService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IUploadPlantService, UploadPlantService>();
        services.AddScoped<IPlantInformationGetterService, PlantInformationGetterService>();
        services.AddScoped<IMetricsService, MetricsService>();
        services.AddScoped<IGetRiskAlertsHandler, GetRiskAlertsHandler>();
        services.AddScoped<IPlantRecognizerService, PlantRecognizerService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IRecognizePlantHandler, RecognizePlantHandler>();
        services.AddSingleton<ITokenService, TokenService>();
        services.AddScoped<IGenerateTokenHandler, GenerateTokenHandler>();
        services.AddScoped<ISavePlantHandler, SavePlantHandler>();
        services.AddScopedServices<IMetricGetter>();
        services.Configure<JWTOptions>(configuration.GetSection(JWTOptions.SectionName));

        return services;
    }

    private static void AddScopedServices<T>(this IServiceCollection services)
    {
        typeof(ConfigureServices).Assembly.GetTypes()
            .Where(type => type is { IsInterface: false, IsAbstract: false })
            .Where(type => type.GetInterface(typeof(T).Name) != null)
            .Select(type => type.UnderlyingSystemType)
            .ToList()
            .ForEach(type => services.AddScoped(typeof(T), type));
    }
}