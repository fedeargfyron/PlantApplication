using Domain.Dtos.Users;

namespace Application.Handlers.Users.ResetUserPaswordHandler;

public interface IResetUserPaswordHandler
{
    Task<RecoverPasswordResultDto> HandleAsync(ResetUserPaswordHandlerRequest request);
}
