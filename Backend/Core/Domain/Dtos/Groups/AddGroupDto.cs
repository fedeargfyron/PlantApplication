namespace Domain.Dtos.Groups;

public record AddGroupDto(string Name, string Description, List<int> PermissionsIds, List<int> UsersIds);