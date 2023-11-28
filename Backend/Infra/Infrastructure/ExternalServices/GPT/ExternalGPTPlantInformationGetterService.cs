using Domain.Dtos.ExternalServices;
using Domain.Interfaces.ExternalServices;
using Infrastructure.Extensions;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Chat;
using System.Text.Json;

namespace Infrastructure.ExternalServices.ChatGPT;

public class ExternalGPTPlantInformationGetterService : IExternalPlantInformationGetterService
{
    private readonly GPTOptions _options;
    private string _questionTemplate = "Necesito que respondas solo en JSON sobre la planta \"{plant}\" rellenando las siguientes caracteristicas: {\r\n\t\"CommonName\": \"\",\r\n\t\"ScientificName\": \"\",\r\n\t\"Cycle\": (Annual, Biennial, Perennial),\r\n\t\"WateringDaysFrequency\": (1, 2, 3, 2-4, etc),\r\n\t\"Sunlight\": [(Full sun, Full sun to partial shade, Partial shade (or part shade), Dappled sun/shade, Full shade, etc)]\r\n}";

    public ExternalGPTPlantInformationGetterService(IOptions<GPTOptions> options)
    {
        _options = options.Value;
    }

    public async Task<GetPlantInformationByNameResultDto> GetPlantInformationByName(string plantName)
    {
        var api = new OpenAIAPI(_options.ApiKey);
        var request = new ChatRequest()
        {
            Temperature = 0,
            Messages = new List<ChatMessage>
            {
                new(ChatMessageRole.User, _questionTemplate.Replace("{plant}", plantName))
            }
        };
        var result = await api.Chat.CreateChatCompletionAsync(request);
        var resultJson = result.ToString().GetJsonFromText();
        return JsonSerializer.Deserialize<GetPlantInformationByNameResultDto>(resultJson)!;
    }
}
