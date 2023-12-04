using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Handlers;

public interface IPlantHandler
{
    Task<List<Plant>> GetPlantsByUserAsync();
    Task<List<RankedPlantDto>> GetRankedPlantsAsync();
    Task AddPlantAsync(PlantDto dto);
    Task UpdatePlantAsync(int id, UpdatePlantDto dto);
    Task DeletePlant(int id);
    Task<GetPlantByIdResultDto> GetPlantByIdAsync(int id);
}
