using Domain.Entities;

namespace Application.Handlers.Users.GetUserByIdHandler;

public interface IGetUserByIdHandler
{
    ValueTask<User> HandleAsync(GetUserByIdHandlerRequest request);

}
