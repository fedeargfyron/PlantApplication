using Application.Handlers.Plants.RecognizePlantHandler;
using Application.Handlers.Plants.SavePlantHandler;
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
            var result = await handler.GetPlantsAsync();
            return TypedResults.Ok(mapper.Map<List<GetPlantResponse>>(result));
        }).RequireAuthorization(PermissionType.GetPlants.ToString());

        plants.MapGet("/{id}", async (IPlantHandler handler, IMapper mapper, int id) =>
        {
            var result = await handler.GetPlantByIdAsync(id);
            return TypedResults.Ok(mapper.Map<GetPlantResponse>(result));
        }).RequireAuthorization(PermissionType.GetPlantById.ToString());

        plants.MapPut("/{id}", async (IPlantHandler handler, IMapper mapper, int id, PutPlantRequest putPlantRequest) =>
        {
            await handler.UpdatePlantAsync(id, mapper.Map<UpdatePlantDto>(putPlantRequest));
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.ModifyPlants.ToString());

        plants.MapDelete("/{id}", (IPlantHandler handler, int id) =>
        {
            handler.DeletePlant(id);
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.DeletePlants.ToString());

        plants.MapPost("/recognize", async ([FromBody] RecognizePlantHandlerRequest request, IRecognizePlantHandler handler) =>
        {
            await handler.HandleAsync(request);
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.RecognizePlants.ToString());

        plants.MapPost("/", async ([FromBody] SavePlantHandlerRequest request, ISavePlantHandler handler) =>
        {
            await handler.HandleAsync(request);
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionType.SavePlants.ToString());
    }
}
