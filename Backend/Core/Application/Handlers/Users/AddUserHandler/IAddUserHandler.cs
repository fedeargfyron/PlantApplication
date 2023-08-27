namespace Application.Handlers.Users.AddUserHandler;

public interface IAddUserHandler
{
    Task HandleAsync(AddUserHandlerRequest request);

}
