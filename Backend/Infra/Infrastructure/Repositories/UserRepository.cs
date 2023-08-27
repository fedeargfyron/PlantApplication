using Domain.Dtos.Users;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(Context context) : base(context)
    {

    }

    public Task<GetUserLoginResultDto?> GetUserLoginAsync(GetUserLoginDto getUserLoginDto)
        => _context.Users.Where(x => x.Email == getUserLoginDto.Email
            && x.Password == getUserLoginDto.Password)
            .Select(x => new GetUserLoginResultDto
            {
                Email = x.Email,
                Id = x.Id,
                UserName = x.Username,
                Permissions = x.Groups.SelectMany(g => g.Permissions.Select(p => p.Value))
                    .Distinct()
                    .ToList()
            })
            .SingleOrDefaultAsync();

    public void DeleteByIdAsync(int id)
    {
        var user = new User() { Id = id };
        _context.Users.Attach(user);
        _context.Users.Remove(user);
    }

    public async Task UpdateAsync(UpdateUserDto dto)
    {
        var groups = dto.GroupsIds.Select(x => new Group() { Id = x });
        _context.Groups.AttachRange(groups);
        await _context.Users.Where(x => x.Id == dto.Id)
            .ExecuteUpdateAsync(s =>
                s.SetProperty(e => e.Username, e => dto.Username)
                 .SetProperty(e => e.Location, e => dto.Location)
                 .SetProperty(e => e.Groups, e => groups));
    }

    public async Task AddWithRelationsAsync(User entity)
    {
        _context.Groups.AttachRange(entity.Groups);
        await _context.Users.AddAsync(entity);
    }
}
