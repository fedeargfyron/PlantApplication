using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IPlantService
{
    Task<List<Plant>> GetAllAsync();
    Task AddPlantAsync(PlantDto dto);
    Task UpdatePlantAsync(int plantId, UpdatePlantDto dto);
    Task DeletePlantAsync(int id);
    Task<Plant> GetPlantByIdAsync(int id);
}
