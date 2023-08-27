namespace Application.Handlers.Users.UpdateUserHandler;

public interface IUpdateUserHandler
{
    Task HandleAsync(UpdateUserHandlerRequest request);
}
