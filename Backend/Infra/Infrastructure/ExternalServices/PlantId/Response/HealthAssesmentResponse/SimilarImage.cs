using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.PlantId.Response.HealthAssesmentResponse;

public class SimilarImage
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = string.Empty;
}