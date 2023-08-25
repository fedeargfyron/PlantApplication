using Domain.Dtos.Users;

namespace Domain.Interfaces.Services;

public interface IUserService
{
    Task<GetUserLoginResultDto> GetUserLoginAsync(GetUserLoginDto getUserLoginDto);
}
