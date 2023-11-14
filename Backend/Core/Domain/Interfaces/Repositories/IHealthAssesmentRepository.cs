using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IHealthAssesmentRepository
{
    Task<List<GetHealthAssesmentDto>> GetAllAsync(int userId);
    Task AddAsync(HealthAssesment entity);
    Task<GetHealthAssesmentByIdDto> GetHealthAssesmentByIdAsync(int id);
}
