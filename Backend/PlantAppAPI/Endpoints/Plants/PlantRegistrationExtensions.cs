using AutoMapper;
using Domain.Dtos.Plants;
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

        plants.MapPost("/test/imagekit", async ([FromBody] string base64Image, IImageKitHandler handler) =>
        {
            await handler.RecognizePlantAsync(base64Image);
            return TypedResults.Ok();
        });

        plants.MapGet("/", async (IPlantHandler handler, IMapper mapper) => 
        {
            var result = await handler.GetPlantsAsync();
            return TypedResults.Ok(mapper.Map<List<GetPlantResponse>>(result));
        });
        plants.MapGet("/{id}", async (IPlantHandler handler, IMapper mapper, int id) =>
        {
            var result = await handler.GetPlantByIdAsync(id);
            return TypedResults.Ok(mapper.Map<GetPlantResponse>(result));
        });

        plants.MapPost("/", async (IPlantHandler handler, IMapper mapper, PostPlantRequest postPlantRequest) =>
        {
            await handler.AddPlantAsync(mapper.Map<PlantDto>(postPlantRequest));
            return TypedResults.Ok();
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
    }
}
