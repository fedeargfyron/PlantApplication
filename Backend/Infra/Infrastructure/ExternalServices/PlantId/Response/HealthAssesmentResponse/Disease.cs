using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.PlantId.Response.HealthAssesmentResponse;

public class Disease
{
    [JsonPropertyName("suggestions")]
    public List<DiseaseSuggestion> Suggestions { get; set; } = new();
}