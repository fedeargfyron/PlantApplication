using AutoMapper;
using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class PlantRepository : IPlantRepository
{
    private readonly Context _context;
    private readonly IMapper _mapper;
    public PlantRepository(Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddAsync(Plant entity) 
    {
        await _context.Plants.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var plant = await _context.Plants.FindAsync(id);

        if (plant is null)
        {
            throw new InvalidOperationException("Plant doesnt exists");
        }

        _context.Plants.Remove(plant);
    }

    public Task<List<Plant>> GetAllAsync() => _context.Plants.ToListAsync();

    public async Task<Plant> GetByIdAsync(int id)
    {
        var plant = await _context.Plants.FindAsync(id);

        return plant is null ? throw new InvalidOperationException("Plant doesnt exists") : plant;
    }

    public async Task UpdateAsync(int id, UpdatePlantDto dto)
    {
        var plant = await _context.Plants.FindAsync(id);

        if(plant is null)
        {
            throw new InvalidOperationException("Plant doesnt exists");
        }

        plant.Outside = dto.Outside;
        plant.CommonName = dto.Name;
        await _context.SaveChangesAsync();
    }
}
