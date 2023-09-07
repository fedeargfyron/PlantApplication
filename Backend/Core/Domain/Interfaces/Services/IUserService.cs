using Domain.Dtos.Users;
using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IUserService
{
    Task AddUserAsync(AddUserDto dto);
    Task DeleteUserByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task<GetUserByIdResultDto> GetUserByIdAsync(int id);
    Task UpdateUserAsync(UpdateUserDto dto);
    Task<GetUserLoginResultDto> GetUserLoginAsync(GetUserLoginDto getUserLoginDto);
}
