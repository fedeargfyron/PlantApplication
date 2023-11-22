namespace Application.Handlers.Users.RemoveUserHandler;

public interface IRemoveUserHandler
{
    Task HandleAsync(RemoveUserHandlerRequest request);
}
    