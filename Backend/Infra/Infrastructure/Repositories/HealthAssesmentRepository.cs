using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class HealthAssesmentRepository : IHealthAssesmentRepository
{
    private readonly Context _context;

    public HealthAssesmentRepository(Context context)
    {
        _context = context;
    }

    public Task AddAsync(HealthAssesment entity)
    {
        _context.Add(entity);
        return _context.SaveChangesAsync();
    }

    public Task<List<GetHealthAssesmentDto>> GetAllAsync()
    {
        _context.HealthAssesments.Select(x => new GetHealthAssesmentDto(x.Plant.Name, x.Date));
        throw new NotImplementedException();
    }


}
