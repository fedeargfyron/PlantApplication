using AutoMapper;
using Domain.Dtos.ExternalServices.HealthAssesment;
using Domain.Interfaces.ExternalServices;
using Infrastructure.ExternalServices.PlantId.Request;
using Infrastructure.ExternalServices.PlantId.Response.HealthAssesmentResponse;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Infrastructure.ExternalServices.PlantId;

public class ExternalPlantIdService : IExternalHealthAssesmentService
{
    private readonly HttpClient _client;
    private readonly IMapper _mapper;
    private readonly PlantIdOptions _options;

    public ExternalPlantIdService(HttpClient client, IMapper mapper, IOptions<PlantIdOptions> options)
    {
        _client = client;
        _mapper = mapper;
        _options = options.Value;
    }

    public async Task<HealthAssesmentResultDto> DoHealthAssestment(DoHealthAssestmentRequestDto requestDto)
    {
        _client.BaseAddress = new Uri(_options.BaseUrl);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.DefaultRequestHeaders.Add("Api-Key", _options.ApiKey);
        var response = await _client.PostAsJsonAsync("/api/v3/health_assessment?details=description,common_names,taxonomy", 
            new DoHealthAssesmentRequestBody(
                new () { requestDto.Base64Image },
                requestDto.Latitude,
                requestDto.Longitude,
                true
            ));
        var responseContent = JsonSerializer.Deserialize<GetPlantHealthAssesmentResponse>(await response.Content.ReadAsStringAsync());
        return _mapper.Map<HealthAssesmentResultDto>(responseContent);
    }
}
