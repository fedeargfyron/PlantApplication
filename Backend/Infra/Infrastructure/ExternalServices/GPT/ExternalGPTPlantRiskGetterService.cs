using Domain.Dtos.PlantRisks;
using Domain.Dtos.WateringCalendar;
using Domain.Dtos.Weather.GetWeatherDtoContent;
using Domain.Extensions;
using Domain.Interfaces.ExternalServices;
using Infrastructure.Extensions;
using Infrastructure.ExternalServices.GPT.Contracts;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using OpenAI_API;
using OpenAI_API.Chat;
using System.Text.Json;

namespace Infrastructure.ExternalServices.GPT;

public class ExternalGPTPlantRiskGetterService : IExternalPlantRiskGetterService
{
    private readonly GPTOptions _options;
    private string _questionTemplate = @"En base a las siguientes condiciones climáticas: 
                            {days}
                            Pretende ser un botanico experto y describe para las plantas ({plants}) en un mismo JSON ARRAY un único objeto por planta definiendo los días y riesgos pertinentes con la siguiente estructura, puede haber más de un riesgo por día:
                            [
	                            {
	                              ""Plant"": """",
	                              ""Risks"": [
			                              {
				                              ""Day"": 1,
				                              ""Risk"": ""(Required, only one per object: Rain, Humidity, Temperature or Wind)"",
				                              ""Level"": ""(Required, only one: low, medium or high)"",
				                              ""Description"": ""Why is it a risk""
			                              },
			                              {
				                              ""Day"": 1…
			                              },
			                              {
				                              ""Day"": 2…
			                              },
			                              {
				                              ""Day"": 3…
			                              }
		                              ]
                                }
                            ]
                            ";
    public ExternalGPTPlantRiskGetterService(IOptions<GPTOptions> options)
    {
        _options = options.Value;
    }

    //TODO: Create batch request (2 plants per request)
    public async Task<List<GetPlantRiskResultDto>> GetPlantRisksAsync(List<ForecastDayDto> forecastDays, List<string> plantNames)
    {
        var api = new OpenAIAPI(_options.ApiKey);
        var dayParameters = forecastDays.GetGPTDaysParameter();
        var request = new ChatRequest()
        {
            Temperature = 0,
            Messages = new List<ChatMessage>
            {
                new(ChatMessageRole.User, _questionTemplate.Replace("{days}", dayParameters)
                        .Replace("{plants}", string.Join(", ", plantNames)))
            }
        };
        var response = await api.Chat.CreateChatCompletionAsync(request);
        var result =  JsonSerializer.Deserialize<List<GetPlantRiskResult>>(response.ToString())!;
        var dtos = result.ConvertToDtos();
        return dtos;
    }
}