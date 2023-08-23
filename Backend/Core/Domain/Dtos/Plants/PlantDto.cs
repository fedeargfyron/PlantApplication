﻿namespace Domain.Dtos.Plants;

public class PlantDto
{
    public string ScientificName { get; set; } = string.Empty;
    public string CommonName { get; set; } = string.Empty;
    public string Watering { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; } = string.Empty;
    public string? Cycle { get; set; } = string.Empty;
    public List<string> Sunlight { get; set; } = new();
    public string ImageLink { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public bool Outside { get; set; }
}
