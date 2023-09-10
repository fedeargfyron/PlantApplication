using System.Text.Json.Serialization;

namespace Domain.Dtos.Plants.RecognizePlantResponseDto;

public class Url
{
    //[JsonPropertyName("o")]
    //public string AlternateImageOne { get; set; } = string.Empty;

    [JsonPropertyName("m")]
    public string AlternateImageTwo { get; set; } = string.Empty;
}
