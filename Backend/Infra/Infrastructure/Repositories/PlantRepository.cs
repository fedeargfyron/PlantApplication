using Domain.Constants;
using Domain.Dtos.PlantRisks;
using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Infrastructure.Repositories;

public class PlantRepository : BaseRepository<Plant>, IPlantRepository
{
    public PlantRepository(Context context) : base(context)
    {

    }
    public Task<List<Plant>> GetUserPlantsAsync(int id)
        => _context.Plants.Where(x => x.UserId == id)
                .ToListAsync();

    public async Task AddPlantAsync(Plant entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        Serilog.Log.ForContext(LogOriginConstants.OriginName, LogOriginConstants.AddPlant)
            .Warning("New plant added {data}", entity);
    }

    public void DeleteById(int id)
    {
        var plant = new Plant() { Id = id };
        _context.Plants.Attach(plant);
        _context.Plants.Remove(plant);
        Serilog.Log.ForContext(LogOriginConstants.OriginName, LogOriginConstants.DeletePlant)
            .Warning("Plant deleted {id}", id);
    }

    public Task<GetPlantByIdResultDto?> GetByIdAsync(int id)
        => _context.Plants.Where(x => x.Id == id)
                .Select(x => new GetPlantByIdResultDto()
                {
                    ScientificName = x.ScientificName,
                    CommonName = x.CommonName,
                    Cycle = x.Cycle,
                    Description = x.Description,
                    ImageLink = x.ImageLink,
                    Name = x.Name,
                    Outside = x.Outside,
                    Type = x.Type,
                    WateringDaysFrequency = x.WateringDaysFrequency
                })
                .FirstOrDefaultAsync();

    public async Task UpdateAsync(int id, UpdatePlantDto dto)
    {
        var plant = await _context.Plants
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(s => 
                s.SetProperty(e => e.Name, e => dto.Name)
                 .SetProperty(e => e.Outside, e => dto.Outside)
                 .SetProperty(e => e.Description, e => dto.Description));

        Serilog.Log.ForContext(LogOriginConstants.OriginName, LogOriginConstants.UpdatePlant)
            .Warning("Plant updated {dto}", dto);
    }

    public async Task<List<TodayRisksByPlantResultDto>> TodayRisksByPlant(string scientificName)
    {
        var plant = await _context.Plants.Include(x => x.PlantRisks)
            .FirstOrDefaultAsync(x => x.ScientificName == scientificName);

        if (plant is null)
        {
            return new();
        }
            
        return plant.PlantRisks.Select(x => new TodayRisksByPlantResultDto()
        {
            Day = x.Day,
            Description = x.Description,
            ObtentionDate = x.ObtentionDate,
            Level = x.Level,
            Risk = x.Risk
        }).ToList();
    }

    public Task<List<RankedPlantDto>> GetRankedPlantsAsync()
        => _context.Plants.GroupBy(x => x.ScientificName)
                .Select(x => new RankedPlantDto(
                        x.Count(),
                        x.Key,
                        x.First().CommonName,
                        x.First().WateringDaysFrequency,
                        x.First().Cycle,
                        x.Select(x => x.ImageLink).Take(4).ToList(),
                        x.First().Exterior,
                        x.First().CareLevel))
                .ToListAsync();
}
