using Domain.Dtos.ExternalServices;
using Domain.Interfaces.ExternalServices;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using OpenAI_API;
using System.Text.Json;

namespace Infrastructure.ExternalServices.ChatGPT;

public class ExternalGPTService : IExternalPlantInformationGetterService
{
    private readonly GPTOptions _options;
    private string _questionTemplate = "Necesito que respondas solo en JSON sobre la planta \"{plant}\" con la siguientes caracteristicas: {\r\n\t\"common_name\": \"\",\r\n\t\"scientific_name\": \"\",\r\n\t\"cycle\": \"Perennial, etc\",\r\n\t\"watering\": \"Frequent, etc\",\r\n\t\"sunlight\": []\r\n}";

    public ExternalGPTService(IOptions<GPTOptions> options)
    {
        _options = options.Value;
    }

    public async Task<GetPlantInformationByNameResultDto> GetPlantInformationByName(string plantName)
    {
        var api = new OpenAIAPI(_options.ApiKey);
        var result = await api.Chat.CreateChatCompletionAsync(_questionTemplate.Replace("{plant}", plantName));
        return JsonSerializer.Deserialize<GetPlantInformationByNameResultDto>(result.ToString())!;
    }
}
