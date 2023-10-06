using Domain.Interfaces.Security;
using Domain.Interfaces.Services;

namespace Application.Handlers.Plants.SavePlantHandler;

public class SavePlantHandler : ISavePlantHandler
{
    private readonly IPlantInformationGetterService _plantInformationGetterService;
    private readonly IPlantService _plantService;
    private readonly IApplicationUser _applicationUser;

    public SavePlantHandler(IPlantInformationGetterService plantInformationGetterService, IPlantService plantService, IApplicationUser applicationUser)
    {
        _plantInformationGetterService = plantInformationGetterService;
        _plantService = plantService;
        _applicationUser = applicationUser;
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
            Watering = result.Watering,
            UserId = _applicationUser.GetUserId()
        });
    }
}
