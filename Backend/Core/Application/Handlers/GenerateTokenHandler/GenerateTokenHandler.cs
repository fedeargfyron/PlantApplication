using Domain.Interfaces.Services;

namespace Application.Handlers.GenerateTokenHandler;

public class GenerateTokenHandler : IGenerateTokenHandler
{
    private readonly ITokenService _identityService;
    private readonly IUserService _userService;

    public GenerateTokenHandler(ITokenService identityService, IUserService userService)
    {
        _identityService = identityService;
        _userService = userService;
    }
    public async Task<string> HandleAsync(GenerateTokenHandlerRequest request)
    {
        var getUserLoginResult = await _userService.GetUserLoginAsync(new(request.Email, request.Password));
        return _identityService.GenerateToken(getUserLoginResult);
    }
}