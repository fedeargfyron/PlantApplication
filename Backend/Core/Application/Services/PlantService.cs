using AutoMapper;
using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class PlantService : IPlantService
{
    private readonly IPlantRepository _plantRepository;
    private readonly IMapper _mapper;

    public PlantService(IPlantRepository plantRepository, IMapper mapper)
    {
        _plantRepository = plantRepository;
        _mapper = mapper;
    }

    public async Task AddPlantAsync(PlantDto dto)
    {
        await _plantRepository.AddAsync(_mapper.Map<Plant>(dto));
        await _plantRepository.SaveChangesAsync();
    }

    public void DeletePlantByIdAsync(int id) => _plantRepository.DeleteByIdAsync(id);

    public Task<List<Plant>> GetAllAsync() => _plantRepository.GetAllAsync();

    public async ValueTask<Plant> GetPlantByIdAsync(int id)
    {
        var plant = await _plantRepository.GetByIdAsync(id);
        
        if(plant is null)
        {
            throw new ArgumentException("Plant doesnt exists");
        }

        return plant;
    } 

    public Task UpdatePlantAsync(int plantId, UpdatePlantDto dto) => _plantRepository.UpdateAsync(plantId, dto);
}
