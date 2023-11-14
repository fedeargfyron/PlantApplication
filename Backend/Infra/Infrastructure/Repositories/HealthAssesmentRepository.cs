using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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

    public Task<List<GetHealthAssesmentDto>> GetAllAsync(int userId)
        => _context.HealthAssesments.Where(x => x.UserId == userId).Select(x => new GetHealthAssesmentDto(x.Id, x.Plant.Name, x.Date, x.Disease, x.IsHealthyProbability, x.PlantImage))
            .ToListAsync();

    public Task<GetHealthAssesmentByIdDto> GetHealthAssesmentByIdAsync(int id)
        => _context.HealthAssesments.Where(x => x.Id == id)
                .Select(x => new GetHealthAssesmentByIdDto()
                {
                    Date = x.Date,
                    Disease = x.Disease,
                    DiseaseCommonNames = x.DiseaseCommonNames,
                    DiseaseDescription = x.DiseaseDescription,
                    DiseaseProbability = x.DiseaseProbability,
                    IsHealthy = x.IsHealthy,
                    IsHealthyProbability = x.IsHealthyProbability,
                    PlantImage = x.PlantImage,
                    PlantName = x.Plant.Name
                })
                .SingleAsync();
}
