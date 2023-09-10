using Domain.Dtos.Plants.RecognizePlantResponseDto;
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

    public async Task<RecognizePlantResponseDto> RecognizePlant(string url)
    {
        var plant = await _externalRecognizerService.RecognizePlant(url);

        if (plant is null)
        {
            throw new ArgumentException("Error recognizing the plant");
        }

        plant.Results = plant.Results.Take(3).ToList();
        plant.Results.ForEach(x => x.Images = x.Images.Take(3).ToList());
        return plant;
    }
}
