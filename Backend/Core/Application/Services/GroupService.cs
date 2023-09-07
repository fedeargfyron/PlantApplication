using AutoMapper;
using Domain.Dtos.Groups;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public GroupService(IGroupRepository groupRepository, IMapper mapper)
    {
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task AddGroupAsync(AddGroupDto dto)
    {
        await _groupRepository.AddWithRelationsAsync(_mapper.Map<Group>(dto));
        await _groupRepository.SaveChangesAsync();
    }

    public async Task DeleteGroupByIdAsync(int id)
    {
        _groupRepository.DeleteByIdAsync(id);
        await _groupRepository.SaveChangesAsync();
    }

    public Task<List<Group>> GetAllAsync()
        => _groupRepository.GetAllAsync();

    public async ValueTask<GetGroupByIdResultDto> GetGroupByIdAsync(int id)
    {
        var group = await _groupRepository.GetByIdAsync(id);

        if(group is null)
        {
            throw new ArgumentException("Group doesnt exists");
        }

        return group;
    }

    public Task UpdateGroupAsync(UpdateGroupDto dto)
        => _groupRepository.UpdateAsync(dto);
}
