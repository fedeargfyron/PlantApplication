using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.PlantId.Response.HealthAssesmentResponse;

public class IsHealthy
{
    [JsonPropertyName("probability")]
    public decimal Probability { get; set; }
    [JsonPropertyName("binary")]
    public bool Result { get; set; }
}