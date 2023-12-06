using Domain.Dtos.Users;
using Domain.Interfaces.Services;

namespace Application.Handlers.Users.ChangeUserPaswordHandler;

public class ChangeUserPaswordHandler : IChangeUserPaswordHandler
{
    private readonly IUserService _userService;

    public ChangeUserPaswordHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task HandleAsync(ChangeUserPaswordHandlerRequest request)
        => _userService.ChangePassword(request.Password, request.NewPassword);
}
