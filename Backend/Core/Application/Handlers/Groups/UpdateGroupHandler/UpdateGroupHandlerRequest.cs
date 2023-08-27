namespace Application.Handlers.Groups.UpdateGroupHandler;

public record UpdateGroupHandlerRequest(int Id, string Name, string Description, List<int> PermissionsIds, List<int> UsersIds);