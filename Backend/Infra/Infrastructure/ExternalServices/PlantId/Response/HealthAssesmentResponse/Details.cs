using System.Text.Json.Serialization;

namespace Infrastructure.ExternalServices.PlantId.Response.HealthAssesmentResponse;

public class Details
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = string.Empty;
    [JsonPropertyName("common_names")]
    public List<string> CommonNames { get; set; } = new();
}