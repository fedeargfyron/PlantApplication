namespace PlantAppAPI.Endpoints.Plants.Contracts.Response;

public record GetPlantResponse(int Id, string ScientificName, string CommonName, string ImageLink, string Name);