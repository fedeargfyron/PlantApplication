using Domain.Dtos.PlantRisks;
using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IPlantRepository : IBaseRepository<Plant>
{
    Task<List<Plant>> GetUserPlantsAsync(int id);
    Task UpdateAsync(int id, UpdatePlantDto dto);
    Task AddPlantAsync(Plant entity);
    void DeleteById(int id);
    Task<GetPlantByIdResultDto?> GetByIdAsync(int id);
    Task<List<TodayRisksByPlantResultDto>> TodayRisksByPlant(string scientificName);
    Task<List<RankedPlantDto>> GetRankedPlantsAsync();
}
