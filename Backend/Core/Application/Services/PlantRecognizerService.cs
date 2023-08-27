using Domain.Dtos.Plants.GetPlantResponse;
using Domain.Interfaces.ExternalServices;
using Domain.Interfaces.Services;

namespace Application.Services;

public class PlantRecognizerService : IPlantRecognizerService
{
    private readonly IExternalRecognizerService _externalRecognizerService;

    public PlantRecognizerService(IExternalRecognizerService externalRecognizerService)
    {
        _externalRecognizerService = externalRecognizerService;
    }

    public async Task<GetPlantResponseDto> RecognizePlant(string url)
    {
        var plant = await _externalRecognizerService.RecognizePlant(url);

        if (plant is null)
        {
            throw new ArgumentException("Error recognizing the plant");
        }

        return plant;
    }
}
