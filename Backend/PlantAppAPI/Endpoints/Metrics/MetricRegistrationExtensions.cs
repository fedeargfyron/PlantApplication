using Application.Handlers.Metrics.CreatedUsersAmountHandler;
using Application.Handlers.Metrics.HealthyPlantsAmountHandler;
using Application.Handlers.Metrics.ScansAmountHandler;
using Application.Handlers.Permissions.GetAllPermissionsHandler;
using Domain.Enums;

namespace PlantAppAPI.Endpoints.Metrics;

public static class MetricRegistrationExtensions
{
    public static void RegisterMetricAPIs(this WebApplication app)
    {
        var groups = app.MapGroup("/metrics");

        groups.MapGet("/scanamounts", async (IScansAmountHandler handler) =>
        {
            var result = await handler.HandleAsync(new());
            return TypedResults.Ok(result);
        }).RequireAuthorization();

        groups.MapGet("/healthyplantsamount", async (IHealthyPlantsAmountHandler handler) =>
        {
            var result = await handler.HandleAsync(new());
            return TypedResults.Ok(result);
        }).RequireAuthorization();

        groups.MapGet("/createdusersamount", async (ICreatedUsersAmountHandler handler) =>
        {
            var result = await handler.HandleAsync(new());
            return TypedResults.Ok(result);
        }).RequireAuthorization();
    }
}
