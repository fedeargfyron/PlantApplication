using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IPlantService
{
    Task<List<Plant>> GetAllAsync();
    Task AddPlantAsync(PlantDto dto);
    Task UpdatePlantAsync(int plantId, UpdatePlantDto dto);
    void DeletePlantByIdAsync(int id);
    ValueTask<Plant> GetPlantByIdAsync(int id);
}
