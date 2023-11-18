namespace Application.Handlers.Plants.HealthAssesmentHandler;

public record HealthAssesmentHandlerRequest(string Base64Image, decimal Latitude, decimal Longitude, int PlantId, string FileName);