namespace Domain.Dtos.Groups;

public record GetGroupByIdResultDto(string Name, string Description, IEnumerable<int> PermissionsIds, IEnumerable<int> UsersIds);