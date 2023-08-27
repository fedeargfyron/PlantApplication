namespace Application.Handlers.Users.UpdateUserHandler;

public record UpdateUserHandlerRequest(int Id, string Username, string? Location, List<int> GroupsIds)
{
}
