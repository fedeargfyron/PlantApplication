using Domain.Dtos.Users;

namespace Domain.Interfaces.Repositories;

public interface IUserRepository
{
    Task<GetUserLoginResultDto> GetUserLoginAsync(GetUserLoginDto getUserLoginDto);
}