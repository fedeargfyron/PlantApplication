using Domain.Dtos.Users;

namespace Application.Handlers.Users.ChangeUserPaswordHandler;

public interface IChangeUserPaswordHandler
{
    Task HandleAsync(ChangeUserPaswordHandlerRequest request);
}
