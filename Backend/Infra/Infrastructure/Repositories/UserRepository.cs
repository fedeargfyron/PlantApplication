using Domain.Dtos.Users;
using Domain.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly Context _context;
    public UserRepository(Context context)
    {
        _context = context;
    }

    public Task<GetUserLoginResultDto> GetUserLoginAsync(GetUserLoginDto getUserLoginDto)
    {
        throw new NotImplementedException();
    }
}
