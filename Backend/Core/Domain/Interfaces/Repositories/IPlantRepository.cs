using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IPlantRepository
{
    Task<List<Plant>> GetAllAsync();
    Task<Plant> GetByIdAsync(int id);
    Task AddAsync(Plant entity);
    Task UpdateAsync(int id, UpdatePlantDto dto);
    Task DeleteAsync(int id);
}
