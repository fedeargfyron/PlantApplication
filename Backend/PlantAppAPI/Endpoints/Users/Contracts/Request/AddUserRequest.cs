namespace PlantAppAPI.Endpoints.Users.Contracts.Request;

public record AddUserRequest(string Username, string Email, string? Location, List<int> GroupsIds);