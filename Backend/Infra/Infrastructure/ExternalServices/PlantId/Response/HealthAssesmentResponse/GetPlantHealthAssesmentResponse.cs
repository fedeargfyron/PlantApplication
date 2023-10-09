using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.PlantId.Response.HealthAssesmentResponse;

public class GetPlantHealthAssesmentResponse
{
    [JsonPropertyName("result")]
    public PlantIdResult Result { get; set; } = new();
}