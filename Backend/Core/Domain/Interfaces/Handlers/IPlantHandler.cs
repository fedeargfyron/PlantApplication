using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Handlers;

public interface IPlantHandler
{
    Task<List<Plant>> GetPlantsAsync();
    Task AddPlantAsync(PlantDto dto);
    Task UpdatePlantAsync(int id, UpdatePlantDto dto);
    void DeletePlant(int id);
    ValueTask<Plant> GetPlantByIdAsync(int id);
}
