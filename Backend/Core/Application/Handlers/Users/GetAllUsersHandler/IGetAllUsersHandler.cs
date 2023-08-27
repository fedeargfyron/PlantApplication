using Domain.Entities;

namespace Application.Handlers.Users.GetAllUsersHandler;

public interface IGetAllUsersHandler
{
    Task<List<User>> HandleAsync(GetAllUsersHandlerRequest request);
}
