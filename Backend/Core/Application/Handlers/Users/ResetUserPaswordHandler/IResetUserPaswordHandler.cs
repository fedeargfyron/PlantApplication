using Domain.Dtos.Users;

namespace Application.Handlers.Users.ResetUserPaswordHandler;

public interface IChangeUserPaswordHandler
{
    Task<RecoverPasswordResultDto> HandleAsync(ChangeUserPaswordHandlerRequest request);
}
