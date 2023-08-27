using Domain.Dtos.Users;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task AddWithRelationsAsync(User entity);
    Task<GetUserLoginResultDto?> GetUserLoginAsync(GetUserLoginDto getUserLoginDto);
    void DeleteByIdAsync(int id);
    Task UpdateAsync(UpdateUserDto dto);
}