using Domain.Dtos.ExternalServices;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Services;

namespace Application.Services;

public class PlantInformationGetterService : IPlantInformationGetterService
{
    private readonly IExternalPlantInformationGetterService _externalPlantInformationGetterService;

    public PlantInformationGetterService(IExternalPlantInformationGetterService externalPlantInformationGetterService)
    {
        _externalPlantInformationGetterService = externalPlantInformationGetterService;
    }
    public Task<GetPlantInformationByNameResultDto> GetPlantInformationByName(string plantName) 
        => _externalPlantInformationGetterService.GetPlantInformationByName(plantName);
}
