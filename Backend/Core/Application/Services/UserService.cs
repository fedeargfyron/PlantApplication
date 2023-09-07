using AutoMapper;
using Domain.Dtos.Users;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<GetUserLoginResultDto> GetUserLoginAsync(GetUserLoginDto getUserLoginDto)
    {
        var user = await _userRepository.GetUserLoginAsync(getUserLoginDto);

        if(user == null)
        {
            throw new ArgumentException("User doesnt exists");
        }

        return user;
    }

    public async Task AddUserAsync(AddUserDto dto)
    {
        await _userRepository.AddWithRelationsAsync(_mapper.Map<User>(dto));
        await _userRepository.SaveChangesAsync();
    }

    public async Task DeleteUserByIdAsync(int id)
    {
        _userRepository.DeleteByIdAsync(id);
        await _userRepository.SaveChangesAsync();
    }

    public Task<List<User>> GetAllAsync()
        => _userRepository.GetAllAsync();

    public async Task<GetUserByIdResultDto> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
        {
            throw new ArgumentException("User doesnt exists");
        }

        return user;
    }

    public Task UpdateUserAsync(UpdateUserDto dto)
        => _userRepository.UpdateAsync(dto);
}
