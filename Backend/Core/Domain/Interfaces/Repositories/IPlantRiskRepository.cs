using Domain.Dtos.PlantRisks;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IPlantRiskRepository
{
    Task<bool> TodayPlantRisksExistsAsync();
    Task<List<PlantRiskDto>> GetTodayPlantRisksAsync();

    Task AddAsync(List<PlantRisk> entities);
}
