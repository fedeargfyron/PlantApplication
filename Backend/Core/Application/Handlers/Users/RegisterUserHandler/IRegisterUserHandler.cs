namespace Application.Handlers.Users.RegisterUserHandler;

public interface IRegisterUserHandler
{
    Task HandleAsync(RegisterUserHandlerRequest request);
}
