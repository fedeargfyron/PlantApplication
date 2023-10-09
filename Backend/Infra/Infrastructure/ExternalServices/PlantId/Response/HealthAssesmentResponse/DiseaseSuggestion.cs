using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.PlantId.Response.HealthAssesmentResponse;

public class DiseaseSuggestion
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;
    [JsonPropertyName("probability")]
    public decimal Probability { get; set; }
    [JsonPropertyName("similar_images")]
    public List<SimilarImage> SimilarImages { get; set; } = new();
    [JsonPropertyName("details")]
    public Details Details { get; set; } = new();
}