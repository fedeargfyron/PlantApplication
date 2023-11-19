using Domain.Dtos.Users;
using Domain.Interfaces.Services;

namespace Application.Handlers.Users.RecoverUserPasswordHandler;

public class RecoverUserPasswordHandler : IRecoverUserPasswordHandler
{
    private readonly IUserService _userService;

    public RecoverUserPasswordHandler(IUserService userService)
    {
        _userService = userService;
    }

    public Task<RecoverPasswordResultDto> HandleAsync(RecoverUserPasswordHandlerRequest request)
        => _userService.RecoverPassword(request.Email);
}