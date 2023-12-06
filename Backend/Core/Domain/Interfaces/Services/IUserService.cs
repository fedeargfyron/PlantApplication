using Domain.Dtos.Users;
using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IUserService
{
    Task UpdateUserAsync(UpdateUserDto dto);
    Task AddUserAsync(AddUserDto dto);
    Task DeleteUserByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task<GetUserByIdResultDto> GetUserByIdAsync(int id);
    Task UpdateUserMaximumWateringDate(DateTime newMaximumWateringDate);
    Task<GetUserLoginResultDto> GetUserLoginAsync(GetUserLoginDto getUserLoginDto);
    Task RegisterUserAsync(RegisterUserDto registerUserDto);
    Task<RecoverPasswordResultDto> RecoverPassword(string Email);
    Task ChangePassword(string password, string newPassword);
}
