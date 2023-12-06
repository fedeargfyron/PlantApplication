using Application.Handlers.Plants.GetHealthAssesmentsByIdHandler;
using Application.Handlers.Plants.GetHealthAssesmentsHandler;
using Application.Handlers.Plants.HealthAssesmentHandler;
using Application.Handlers.Plants.RecognizePlantHandler;
using Application.Handlers.Plants.SavePlantHandler;
using Application.Handlers.RiskAlerts.GetRiskAlertsHandler;
using AutoMapper;
using Domain.Dtos.Plants;
using Domain.Enums;
using Domain.Interfaces.Handlers;
using Microsoft.AspNetCore.Mvc;
using PlantAppAPI.Endpoints.Plants.Contracts.Request;
using PlantAppAPI.Endpoints.Plants.Contracts.Response;

namespace PlantAppAPI.Endpoints.Plants;

public static class PlantRegistrationExtensions
{
    public static void RegisterPlantAPIs(this WebApplication app)
    {
        var plants = app.MapGroup("/plants");
        plants.MapGet("/", async (IPlantHandler handler, IMapper mapper) => 
        {
            var result = await handler.GetPlantsByUserAsync();
            return TypedResults.Ok(mapper.Map<List<GetPlantResponse>>(result));
        }).RequireAuthorization(PermissionType.GetPlants.ToString());

        plants.MapGet("/ranked", async (IPlantHandler handler, IMapper mapper) =>
        {
            var result = await handler.GetRankedPlantsAsync();
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.GetRankedPlants.ToString());

        plants.MapGet("/{id}", async (IPlantHandler handler, IMapper mapper, int id) =>
        {
            var result = await handler.GetPlantByIdAsync(id);
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.GetPlantById.ToString());

        plants.MapPut("/{id}", async (IPlantHandler handler, IMapper mapper, int id, PutPlantRequest putPlantRequest) =>
        {
            await handler.UpdatePlantAsync(id, mapper.Map<UpdatePlantDto>(putPlantRequest));
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.ModifyPlants.ToString());

        plants.MapDelete("/{id}", async (IPlantHandler handler, int id) =>
        {
            await handler.DeletePlant(id);
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.DeletePlants.ToString());

        plants.MapPost("/recognize", async ([FromBody] RecognizePlantHandlerRequest request, IRecognizePlantHandler handler) =>
        {
            var result = await handler.HandleAsync(request);
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.RecognizePlants.ToString());

        plants.MapGet("/healthassesment", async (IGetHealthAssesmentsHandler handler) =>
        {
            var result = await handler.HandleAsync(new GetHealthAssesmentsHandlerRequest());
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.GetHealthAssesments.ToString());

        plants.MapGet("/healthassesment/{id}", async (IGetHealthAssesmentByIdHandler handler, int id) =>
        {
            var result = await handler.HandleAsync(new GetHealthAssesmentByIdHandlerRequest(id));
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.GetHealthAssesmentById.ToString());

        plants.MapPost("/healthassesment", async ([FromBody] HealthAssesmentHandlerRequest request, IHealthAssesmentHandler handler) =>
        {
            var result = await handler.HandleAsync(request);
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.DoHealthAssesments.ToString());

        plants.MapPost("/riskalerts", async ([FromBody] GetRiskAlertsHandlerRequest request, IGetRiskAlertsHandler handler) =>
        {
            var result = await handler.HandleAsync(request);
            return TypedResults.Ok(result);
        }).RequireAuthorization(PermissionType.GetRiskAlerts.ToString());

        plants.MapPost("/", async ([FromBody] SavePlantHandlerRequest request, ISavePlantHandler handler) =>
        {
            await handler.HandleAsync(request);
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.SavePlants.ToString());
    }
}
