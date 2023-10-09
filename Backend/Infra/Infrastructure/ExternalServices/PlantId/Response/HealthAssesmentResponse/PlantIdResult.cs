using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.PlantId.Response.HealthAssesmentResponse;
public class PlantIdResult
{
    [JsonPropertyName("is_healthy")]
    public IsHealthy IsHealthy { get; set; } = new();
    [JsonPropertyName("disease")]
    public Disease Disease { get; set; } = new();
}