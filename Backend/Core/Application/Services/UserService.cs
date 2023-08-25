using Domain.Dtos.Users;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public Task<GetUserLoginResultDto> GetUserLoginAsync(GetUserLoginDto getUserLoginDto)
        => _userRepository.GetUserLoginAsync(getUserLoginDto);
}
