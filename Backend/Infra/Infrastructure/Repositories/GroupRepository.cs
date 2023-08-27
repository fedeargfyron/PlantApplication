using Domain.Dtos.Groups;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GroupRepository : BaseRepository<Group>, IGroupRepository
{
    public GroupRepository(Context context) : base (context)
    {
        
    }

    public async Task AddWithRelationsAsync(Group entity)
    {
        _context.Permissions.AttachRange(entity.Permissions);
        _context.Users.AttachRange(entity.Users);
        await _context.Groups.AddAsync(entity);
    }

    public void DeleteByIdAsync(int id)
    {
        var group = new Group() { Id = id };
        _context.Groups.Attach(group);
        _context.Groups.Remove(group);
    }

    public Task UpdateAsync(UpdateGroupDto dto)
    {
        var users = dto.UsersIds.Select(x => new User() { Id = x });
        var permissions = dto.PermissionsIds.Select(x => new Permission() { Id = x });
        _context.Users.AttachRange(users);
        _context.Permissions.AttachRange(permissions);
        return _context.Groups.Where(x => x.Id == dto.Id)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(e => e.Name, e => dto.Name)
                 .SetProperty(e => e.Description, e => dto.Description)
                 .SetProperty(e => e.Permissions, e => permissions)
                 .SetProperty(e => e.Users, e => users));
    }
}
