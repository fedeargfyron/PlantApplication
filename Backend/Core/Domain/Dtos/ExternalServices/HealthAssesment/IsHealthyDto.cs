using System.Text.Json.Serialization;

namespace Domain.Dtos.ExternalServices.HealthAssesment;

public class IsHealthyDto
{
    public decimal Probability { get; set; }
    [JsonPropertyName("Binary")]
    public bool Result { get; set; }
}