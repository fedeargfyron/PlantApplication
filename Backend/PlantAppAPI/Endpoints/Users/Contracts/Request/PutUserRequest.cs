namespace PlantAppAPI.Endpoints.Users.Contracts.Request;

public record PutUserRequest(string Username, string? Location, List<int> GroupsIds);