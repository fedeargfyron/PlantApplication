using Domain.Dtos.PlantRisks;
using Domain.Entities;
using Domain.Functions;
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

    public async Task AddAsync(List<PlantRisk> entities)
    {
        if(await _context.PlantRisks.AnyAsync(x => x.ObtentionDate == DateTime.Today))
        {
            return;
        }
        _context.PlantRisks.AddRange(PlantRisksFunctions.CleanPlantRisks(entities));
        await _context.SaveChangesAsync();
    }

    public Task<List<PlantRiskDto>> GetTodayPlantRisksAsync()
        => _context.Plants.Select(x => new PlantRiskDto()
            {
                Outside = x.Outside,
                PlantId = x.Id,
                PlantScientificName = x.ScientificName,
                Risks = x.PlantRisks.Where(r => r.ObtentionDate == DateTime.Today)
                                    .Select(r => new RiskDto()
                                    {
                                        Day = r.Day,
                                        Risk = r.Risk,
                                        Description = r.Description,
                                        Level = r.Level
                                    }).ToList()
            }).ToListAsync();
}
