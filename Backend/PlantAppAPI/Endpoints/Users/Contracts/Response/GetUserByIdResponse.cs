namespace PlantAppAPI.Endpoints.Users.Contracts.Response;

public record GetUserByIdResponse(string Username, string Email, string Location, List<int> GroupsIds);