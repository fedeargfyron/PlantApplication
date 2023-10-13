using Domain.Dtos.PlantRisks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PlantRiskRepository : IPlantRiskRepository
{
    private readonly Context _context;

    public PlantRiskRepository(Context context)
    {
        _context = context;
    }

    //TODO: Implement cache
    public Task<bool> TodayPlantRisksExistsAsync()
        => _context.PlantRisks.AnyAsync(x => x.ObtentionDate == DateTime.Today);

    public Task<List<PlantRiskDto>> GetTodayPlantRisksAsync()
        => _context.Plants
            .Select(x => new PlantRiskDto
            {
                Outside = x.Outside,
                PlantId = x.Id,
                PlantScientificName = x.ScientificName,
                Risks = x.PlantRisks.Where(r => r.ObtentionDate == DateTime.Today).Select(r => new RiskDto()
                {
                    Day = r.Day,
                    Risk = r.Risk,
                    Description = r.Description,
                    Level = r.Level
                }).ToList()
            }).ToListAsync();

    public Task AddAsync(List<PlantRisk> entities)
    {
        _context.PlantRisks.AddRange(entities);
        return _context.SaveChangesAsync();
    }
}
