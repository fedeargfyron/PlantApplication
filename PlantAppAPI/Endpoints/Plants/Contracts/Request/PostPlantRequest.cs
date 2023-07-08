namespace PlantAppAPI.Endpoints.Plants.Contracts.Request;

public record PostPlantRequest(string ScientificName, string CommonName, string? Description, string ImageLink, string Type, bool Outside);