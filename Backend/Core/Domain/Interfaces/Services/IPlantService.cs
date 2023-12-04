using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IPlantService
{
    Task<List<Plant>> GetAllByUserAsync();
    Task<List<RankedPlantDto>> GetRankedPlantsAsync();
    Task AddPlantAsync(PlantDto dto);
    Task UpdatePlantAsync(int plantId, UpdatePlantDto dto);
    Task DeletePlantByIdAsync(int id);
    Task<GetPlantByIdResultDto> GetPlantByIdAsync(int id);
}
