using Domain.Dtos.Metrics;
using Domain.Dtos.Users;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task AddWithRelationsAsync(User entity);
    Task<GetUserLoginResultDto?> GetUserLoginAsync(GetUserLoginDto getUserLoginDto);
    Task UpdateUserMaximumWateringDate(int userId, DateTime newMaximumWateringDate);
    void DeleteByIdAsync(int id);
    Task UpdateAsync(UpdateUserDto dto);
    Task<GetUserByIdResultDto?> GetByIdAsync(int id);
    Task<List<AmountByMonthDto>> GetCreatedUsersAmountByMonthAsync();
    Task<User?> GetUserByEmailAsync(string email);
    Task<User?> GetEntityByIdAsync(int id);
}