using AutoMapper;
using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Security;
using Domain.Interfaces.Services;

namespace Application.Services;

public class PlantService : IPlantService
{
    private readonly IPlantRepository _plantRepository;
    private readonly IApplicationUser _applicationUser;
    private readonly IMapper _mapper;

    public PlantService(IPlantRepository plantRepository, IApplicationUser applicationUser, IMapper mapper)
    {
        _plantRepository = plantRepository;
        _applicationUser = applicationUser;
        _mapper = mapper;
    }

    public Task AddPlantAsync(PlantDto dto)
        => _plantRepository.AddPlantAsync(_mapper.Map<Plant>(dto));

    public void DeletePlantByIdAsync(int id) => _plantRepository.DeleteByIdAsync(id);

    public Task<List<Plant>> GetAllAsync() 
        => _plantRepository.GetUserPlantsAsync(_applicationUser.GetUserId());

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
