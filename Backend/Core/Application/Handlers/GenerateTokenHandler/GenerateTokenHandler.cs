using Application.Helpers;
using Domain.Constants;
using Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Application.Handlers.GenerateTokenHandler;

public class GenerateTokenHandler : IGenerateTokenHandler
{
    private readonly ITokenService _identityService;
    private readonly IUserService _userService;
    private readonly ILogger<GenerateTokenHandler> _logger;

    public GenerateTokenHandler(ITokenService identityService, IUserService userService, ILogger<GenerateTokenHandler> logger)
    {
        _identityService = identityService;
        _userService = userService;
        _logger = logger;
    }
    public async Task<string> HandleAsync(GenerateTokenHandlerRequest request)
    {
        Log.ForContext("Origin", LogOriginConstants.Login)
            .Warning("User attempted to login. {data}", request);
        var encryptedPassword = EncryptionHelper.Encrypt(request.Password);
        var getUserLoginResult = await _userService.GetUserLoginAsync(new(request.Email, encryptedPassword));
        return _identityService.GenerateToken(getUserLoginResult);
    }
}