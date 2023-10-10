﻿namespace Domain.Dtos.ExternalServices;

public class GetPlantInformationByNameResultDto
{
    public string CommonName { get; set; } = string.Empty;
    public string ScientificName { get; set; } = string.Empty;
    public string Cycle { get; set; } = string.Empty;
    public string WateringDaysFrequency { get; set; } = string.Empty;
    public List<string> Sunlight { get; set; } = new();
}
