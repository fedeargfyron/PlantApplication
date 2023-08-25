using Application.Handlers.RecognizePlantHandler;
using Application.Handlers.SavePlantHandler;
using AutoMapper;
using Domain.Dtos.Plants;
using Domain.Enums;
using Domain.Interfaces.Handlers;
using Microsoft.AspNetCore.Authorization;
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
        }).RequireAuthorization(PermissionEnum.GetPlants.ToString());


        plants.MapGet("/{id}", async (IPlantHandler handler, IMapper mapper, int id) =>
        {
            var result = await handler.GetPlantByIdAsync(id);
            return TypedResults.Ok(mapper.Map<GetPlantResponse>(result));
        });

        plants.MapPut("/{id}", async (IPlantHandler handler, IMapper mapper, int id, PutPlantRequest putPlantRequest) =>
        {
            await handler.UpdatePlantAsync(id, mapper.Map<UpdatePlantDto>(putPlantRequest));
            return TypedResults.Ok();
        });

        plants.MapDelete("/{id}", async (IPlantHandler handler, int id) =>
        {
            await handler.DeletePlantAsync(id);
            return TypedResults.Ok();
        });

        plants.MapPost("/recognize", async ([FromBody] RecognizePlantHandlerRequest request, IRecognizePlantHandler handler) =>
        {
            await handler.HandleAsync(request);
            return TypedResults.Ok();
        }).RequireAuthorization(PermissionEnum.RecognizePlants.ToString());

        plants.MapPost("/", async ([FromBody] SavePlantHandlerRequest request, ISavePlantHandler handler) =>
        {
            await handler.HandleAsync(request);
            return TypedResults.Ok();
        });
    }
}
