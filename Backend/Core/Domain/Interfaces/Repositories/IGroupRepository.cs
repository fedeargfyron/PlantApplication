using Domain.Dtos.Groups;
using Domain.Entities;

namespace Domain.Interfaces.Repositories;

public interface IGroupRepository : IBaseRepository<Group>
{
    Task AddWithRelationsAsync(Group entity);
    void DeleteByIdAsync(int id);
    Task UpdateAsync(UpdateGroupDto dto);
    Task<GetGroupByIdResultDto?> GetByIdAsync(int id);
}
