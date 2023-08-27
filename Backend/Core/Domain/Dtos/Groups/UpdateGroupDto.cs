namespace Domain.Dtos.Groups;

public record UpdateGroupDto(int Id, string Name, string Description, List<int> PermissionsIds, List<int> UsersIds);