namespace Domain.Dtos.Plants;

public record GetHealthAssesmentDto(int Id, string PlantName, DateTime Date, string Disease, decimal IsHealthyProbability, string PlantImage);