namespace PlantAppAPI.Endpoints.Groups.Contracts.Request;

public record PutGroupRequest(string Name, string Description, List<int> PermissionsIds, List<int> UsersIds);