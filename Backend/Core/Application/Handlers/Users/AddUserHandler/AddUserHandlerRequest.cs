namespace Application.Handlers.Users.AddUserHandler;

public record AddUserHandlerRequest(string Username, string Email, string? Location, List<int> GroupsIds);