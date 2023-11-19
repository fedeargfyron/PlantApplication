using Domain.Dtos.Users;

namespace Application.Handlers.Users.RecoverUserPasswordHandler;

public interface IRecoverUserPasswordHandler
{
    Task<RecoverPasswordResultDto> HandleAsync(RecoverUserPasswordHandlerRequest request);
}
