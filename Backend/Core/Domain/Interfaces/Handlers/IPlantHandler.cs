using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Handlers;

public interface IPlantHandler
{
    Task<List<Plant>> GetPlantsAsync();
    Task AddPlantAsync(PlantDto dto);
    Task UpdatePlantAsync(int id, UpdatePlantDto dto);
    Task DeletePlantAsync(int id);
    Task<Plant> GetPlantByIdAsync(int id);
}
