namespace Infrastructure.ExternalServices.PlantId.Request;

public record DoHealthAssesmentRequestBody(List<string> Images, decimal Latitude, decimal Longitude, bool Similar_images);