namespace Application.Handlers.Groups.AddGroupHandler;

public record AddGroupHandlerRequest(string Name, string Description, List<int> PermissionsIds, List<int> UsersIds);