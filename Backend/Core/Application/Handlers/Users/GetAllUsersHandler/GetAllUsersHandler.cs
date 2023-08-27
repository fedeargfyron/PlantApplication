using Domain.Entities;
using Domain.Interfaces.Services;

namespace Application.Handlers.Users.GetAllUsersHandler;

public class GetAllUsersHandler : IGetAllUsersHandler
{
    private readonly IUserService _userService;

    public GetAllUsersHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task<List<User>> HandleAsync(GetAllUsersHandlerRequest request)
        => _userService.GetAllAsync();
}
