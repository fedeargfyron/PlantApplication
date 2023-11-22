using Domain.Dtos.Groups;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Extensions;
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

    public async Task UpdateAsync(UpdateGroupDto dto)
    {
        var group = await _context.Groups.Include(x => x.Permissions)
            .Include(x => x.Users)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if(group == null)
        {
            throw new ArgumentException("Group doesnt exists");
        }

        group.Users.SetNewEntities(dto.UsersIds, _context, id => new User { Id = id });
        group.Permissions.SetNewEntities(dto.PermissionsIds, _context, id => new Permission { Id = id });
        group.Name = dto.Name;
        group.Description = dto.Description;
        await _context.SaveChangesAsync();
    }

    public Task<GetGroupByIdResultDto?> GetByIdAsync(int id)
        => _context.Groups.Where(x => x.Id == id)
            .Select(x => new GetGroupByIdResultDto(x.Name, x.Description, x.Permissions.Select(x => x.Id), x.Users.Select(x => x.Id)))
            .SingleOrDefaultAsync();
}
