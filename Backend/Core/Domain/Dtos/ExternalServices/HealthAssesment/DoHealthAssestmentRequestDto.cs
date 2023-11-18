namespace Domain.Dtos.ExternalServices.HealthAssesment;

public record DoHealthAssestmentRequestDto(string Base64Image, decimal Latitude, decimal Longitude, int PlantId, string FileName);