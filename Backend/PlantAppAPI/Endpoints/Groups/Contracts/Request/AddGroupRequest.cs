namespace PlantAppAPI.Endpoints.Groups.Contracts.Request
{
    public record AddGroupRequest(string Name, string Description, List<int> PermissionsIds, List<int> UsersIds);
}
