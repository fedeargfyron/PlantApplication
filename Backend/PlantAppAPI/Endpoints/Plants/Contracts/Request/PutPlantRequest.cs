namespace PlantAppAPI.Endpoints.Plants.Contracts.Request;

public record PutPlantRequest(string Name, bool Outside, string Description);