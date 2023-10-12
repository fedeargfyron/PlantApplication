using Domain.Dtos.PlantRisks;
using Domain.Dtos.Weather.GetWeatherDtoContent;
using Domain.Extensions;
using Domain.Interfaces.ExternalServices;
using Infrastructure.Extensions;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using OpenAI_API;
using System.Text;
using System.Text.Json;

namespace Infrastructure.ExternalServices.GPT;

public class ExternalGPTPlantRiskGetterService : IExternalPlantRiskGetterService
{
    private readonly GPTOptions _options;
    private string _questionTemplate = "Dada las siguientes condiciones climáticas en los días:\r\n{days}. Necesito que me respondas solo y en un mismo JSON ARRAY un objeto para cada uno de los días  para las plantas: {plants}, con los siguientes datos (De ser necesario, si no hay riesgo no agregar el objeto): [{\r\n  \"Plant\": \"\",\r\n  \"Risks\": [\r\n\t\t  {\r\n\t\t\t \"Day\": 1,\r\n \"Risk\": (Rain, humidity, temperature, wind),\r\n\t\t\t  \"Level\": \"(low, medium, high)\",\r\n\t\t\t  \"Description\": \"Why it is a risk\"\r\n\t\t  }\r\n\t  ]\r\n  }]";
    private string _test = @"With these climatic conditions: {days}
                            Output a valid JSON Array with objects for these plants: {plants}, 
                            describing each day risks (Add risk object only if there is a risk):
                            [                            
                                {
                                ""Plant"": """",
                                ""Risks"": [
		                                {
                                            ""Day"": 1,
			                                ""Risk"": (Rain, humidity, temperature or wind),
			                                ""Level"": ""(low, medium or high)"",
			                                ""Description"": ""Why it is a risk""
		                                }
	                                ]
                                }
                            ]";
    public ExternalGPTPlantRiskGetterService(IOptions<GPTOptions> options)
    {
        _options = options.Value;
    }

    public async Task<List<GetPlantRiskResultDto>> GetPlantRisksAsync(List<ForecastDayDto> forecastDays, List<string> plantNames)
    {
        var api = new OpenAIAPI(_options.ApiKey);
        var dayParameters = forecastDays.GetGPTDaysParameter();
        var result = await api.Chat.CreateChatCompletionAsync(_questionTemplate.Replace("{days}", dayParameters)
                .Replace("{plants}", string.Join(", ", plantNames)));
        var resultJson = result.ToString();
        return JsonSerializer.Deserialize<List<GetPlantRiskResultDto>>(resultJson)!;
    }
}
