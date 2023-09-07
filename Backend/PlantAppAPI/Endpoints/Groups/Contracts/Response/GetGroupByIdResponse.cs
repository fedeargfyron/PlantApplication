namespace PlantAppAPI.Endpoints.Groups.Contracts.Response;

public record GetGroupByIdResponse(string Name, string Description, List<int> PermissionsIds, List<int> UsersIds);
