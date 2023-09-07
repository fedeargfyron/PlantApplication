using Domain.Dtos.Users;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Extensions;

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
        var user = await _context.Users.Include(x => x.Groups)
            .FirstOrDefaultAsync(x => x.Id == dto.Id);

        if (user == null)
        {
            throw new ArgumentException("Group doesnt exists");
        }

        user.Groups.SetNewEntities(dto.GroupsIds, _context, id => new Group { Id = id });
        user.Username = dto.Username;
        user.Location = dto.Location;

        await _context.SaveChangesAsync();
    }

    public async Task AddWithRelationsAsync(User entity)
    {
        _context.Groups.AttachRange(entity.Groups);
        await _context.Users.AddAsync(entity);
    }

    public ValueTask<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
