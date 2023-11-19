using Domain.Dtos.Users;
using Domain.Interfaces.Services;

namespace Application.Handlers.Users.ResetUserPaswordHandler;

public class ResetUserPaswordHandler : IResetUserPaswordHandler
{
    private readonly IUserService _userService;

    public ResetUserPaswordHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task<RecoverPasswordResultDto> HandleAsync(ResetUserPaswordHandlerRequest request)
        => _userService.RecoverPassword(request.Email);
}
