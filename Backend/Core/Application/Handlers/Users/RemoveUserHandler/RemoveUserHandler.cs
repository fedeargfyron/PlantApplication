using Domain.Interfaces.Services;

namespace Application.Handlers.Users.RemoveUserHandler;

public class RemoveUserHandler : IRemoveUserHandler
{
    private readonly IUserService _userService;

    public RemoveUserHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task HandleAsync(RemoveUserHandlerRequest request)
        => _userService.DeleteUserByIdAsync(request.UserId);
}

