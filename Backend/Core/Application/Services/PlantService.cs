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

    public Task AddPlantAsync(PlantDto dto) => _plantRepository.AddAsync(_mapper.Map<Plant>(dto));

    public Task DeletePlantAsync(int id) => _plantRepository.DeleteAsync(id);

    public Task<List<Plant>> GetAllAsync() => _plantRepository.GetAllAsync();

    public Task<Plant> GetPlantByIdAsync(int id) => _plantRepository.GetByIdAsync(id);

    public Task UpdatePlantAsync(int plantId, UpdatePlantDto dto) => _plantRepository.UpdateAsync(plantId, dto);
}
