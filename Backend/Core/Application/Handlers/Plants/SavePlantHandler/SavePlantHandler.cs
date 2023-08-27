using Domain.Interfaces.Services;

namespace Application.Handlers.Plants.SavePlantHandler;

public class SavePlantHandler : ISavePlantHandler
{
    private readonly IPlantInformationGetterService _plantInformationGetterService;
    private readonly IPlantService _plantService;

    public SavePlantHandler(IPlantInformationGetterService plantInformationGetterService, IPlantService plantService)
    {
        _plantInformationGetterService = plantInformationGetterService;
        _plantService = plantService;
    }
    public async Task HandleAsync(SavePlantHandlerRequest request)
    {
        var result = await _plantInformationGetterService.GetPlantInformationByName(request.ScientificName);
        await _plantService.AddPlantAsync(new()
        {
            Name = request.Name,
            ImageLink = request.ImageUrl,
            Outside = request.Outside,
            CommonName = result.CommonName,
            Cycle = result.Cycle,
            ScientificName = result.ScientificName,
            Sunlight = result.Sunlight,
            Watering = result.Watering
        });
    }
}
