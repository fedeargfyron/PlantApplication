using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class PlantService : IPlantService
{
    private readonly IPlantRepository _plantRepository;
    public PlantService(IPlantRepository plantRepository)
    {
        _plantRepository = plantRepository;
    }

    public Task AddPlantAsync(PlantDto dto) => _plantRepository.AddAsync(dto);

    public Task DeletePlantAsync(int id) => _plantRepository.DeleteAsync(id);

    public Task<List<Plant>> GetAllAsync() => _plantRepository.GetAllAsync();

    public Task<Plant> GetPlantByIdAsync(int id) => _plantRepository.GetByIdAsync(id);

    public Task UpdatePlantAsync(int plantId, UpdatePlantDto dto) => _plantRepository.UpdateAsync(plantId, dto);
}
