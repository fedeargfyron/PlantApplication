using Domain.Dtos.Plants.GetPlantResponse;
using Domain.Interfaces.ExternalServices;
using Infrastructure.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace Infrastructure.ExternalServices.PlantNet;

public class ExternalPlantNetService : IExternalRecognizerService
{
    private readonly HttpClient _client;
    private readonly PlantNetOptions _options;

    public ExternalPlantNetService(HttpClient client, IOptions<PlantNetOptions> options)
    {
        _client = client;
        _options = options.Value;
    }

    public async Task<GetPlantResponseDto?> RecognizePlant(string url)
    {
        _client.BaseAddress = new Uri(_options.BaseUrl);
        return await _client.GetFromJsonAsync<GetPlantResponseDto>($"v2/identify/{"all"}?api-key={_options.ApiKey}&images={url}&include-related-images=true");
    }
}

