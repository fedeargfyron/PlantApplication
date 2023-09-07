using Domain.Dtos.Groups;
using Domain.Dtos.Plants;
using Domain.Entities;

namespace Domain.Interfaces.Services;

public interface IGroupService
{
    Task<List<Group>> GetAllAsync();
    Task AddGroupAsync(AddGroupDto dto);
    Task UpdateGroupAsync(UpdateGroupDto dto);
    Task DeleteGroupByIdAsync(int id);
    ValueTask<GetGroupByIdResultDto> GetGroupByIdAsync(int id);
}
