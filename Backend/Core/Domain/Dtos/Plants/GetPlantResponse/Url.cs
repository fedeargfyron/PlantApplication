using System.Text.Json.Serialization;

namespace Domain.Dtos.Plants.GetPlantResponse;

public class Url
{
    [JsonPropertyName("o")]
    public string AlternateImageOne { get; set; } = string.Empty;

    [JsonPropertyName("m")]
    public string AlternateImageTwo { get; set; } = string.Empty;

    [JsonPropertyName("s")]
    public string AlternateImageThree { get; set; } = string.Empty;
}
