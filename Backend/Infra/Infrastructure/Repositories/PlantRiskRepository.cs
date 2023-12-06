﻿using Domain.Dtos.PlantRisks;
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

    public Task<List<GetPlantRiskResultDto>> GetTodayPlantRisksAsync()
        => _context.Plants
            .Select(x => new GetPlantRiskResultDto
            {
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
        _context.PlantRisks.AddRange(PlantRisksFunctions.CleanPlantRisks(entities));
        return _context.SaveChangesAsync();
    }
}
