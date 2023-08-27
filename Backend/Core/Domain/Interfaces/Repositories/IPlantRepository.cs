using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IPlantRepository : IBaseRepository<Plant>
{
    Task UpdateAsync(int id, UpdatePlantDto dto);
    void DeleteByIdAsync(int id);
}
