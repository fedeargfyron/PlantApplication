using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IHealthAssesmentRepository
{
    Task<List<GetHealthAssesmentDto>> GetAllAsync();
    Task AddAsync(HealthAssesment entity);
}
