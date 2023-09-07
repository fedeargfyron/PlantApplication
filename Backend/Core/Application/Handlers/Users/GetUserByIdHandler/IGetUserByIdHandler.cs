using Domain.Dtos.Users;
using Domain.Entities;

namespace Application.Handlers.Users.GetUserByIdHandler;

public interface IGetUserByIdHandler
{
    Task<GetUserByIdResultDto> HandleAsync(GetUserByIdHandlerRequest request);

}
