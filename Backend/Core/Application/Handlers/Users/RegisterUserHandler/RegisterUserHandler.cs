using Domain.Interfaces.Services;

namespace Application.Handlers.Users.RegisterUserHandler;

public class RegisterUserHandler : IRegisterUserHandler
{
    private readonly IUserService _userService;

    public RegisterUserHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task HandleAsync(RegisterUserHandlerRequest request)
        => _userService.RegisterUserAsync(new(request.Username, request.Email, request.Password));
}
