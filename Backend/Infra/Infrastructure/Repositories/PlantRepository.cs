using AutoMapper;
using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

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
    }

    public void DeleteByIdAsync(int id)
    {
        var plant = new Plant() { Id = id };
        _context.Plants.Attach(plant);
        _context.Plants.Remove(plant);
    }

    public ValueTask<Plant?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(int id, UpdatePlantDto dto)
    {
        var plant = await _context.Plants
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(s => 
                s.SetProperty(e => e.Name, e => dto.Name)
                 .SetProperty(e => e.Outside, e => dto.Outside));
    }
}
