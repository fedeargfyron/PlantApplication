using Domain.Dtos.Plants;
using Domain.Entities;
using Domain.Interfaces.Handlers;
using Domain.Interfaces.Services;

namespace Application.Handlers.Plants
{
    public class PlantHandler : IPlantHandler
    {
        private readonly IPlantService _plantService;
        public PlantHandler(IPlantService plantService)
        {
            _plantService = plantService;
        }

        public Task AddPlantAsync(PlantDto dto) 
            => _plantService.AddPlantAsync(dto);

        public Task DeletePlant(int id) 
            => _plantService.DeletePlantByIdAsync(id);

        public Task<GetPlantByIdResultDto> GetPlantByIdAsync(int id) 
            => _plantService.GetPlantByIdAsync(id);

        public Task<List<Plant>> GetPlantsByUserAsync() 
            => _plantService.GetAllByUserAsync();

        public Task<List<RankedPlantDto>> GetRankedPlantsAsync()
            => _plantService.GetRankedPlantsAsync();

        public Task UpdatePlantAsync(int id, UpdatePlantDto dto) 
            => _plantService.UpdatePlantAsync(id, dto);
    }
}
