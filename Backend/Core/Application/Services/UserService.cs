using Application.Helpers;
using AutoMapper;
using Domain.Dtos.Users;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Security;
using Domain.Interfaces.Services;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IApplicationUser _applicationUser;

    public UserService(IUserRepository userRepository, IMapper mapper, IApplicationUser applicationUser)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _applicationUser = applicationUser;
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

    public Task UpdateUserMaximumWateringDate(DateTime newMaximumWateringDate)
    {
        var userId = _applicationUser.GetUserId();
        return _userRepository.UpdateUserMaximumWateringDate(userId, newMaximumWateringDate);
    }

    public Task RegisterUserAsync(RegisterUserDto registerUserDto)
    {
        var encryptedPassword = EncryptionHelper.Encrypt(registerUserDto.Password);
        _userRepository.Add(new User()
        {
            Username = registerUserDto.Username,
            Password = encryptedPassword,
            Email = registerUserDto.Email
        });
        return _userRepository.SaveChangesAsync();
    }

    public async Task<RecoverPasswordResultDto> RecoverPassword(string Email)
    {
        var user = await _userRepository.GetUserByEmailAsync(Email);

        if(user is null)
        {
            throw new ArgumentException($"Email is invalid");
        }

        var newPassword = PasswordHelper.Generate(10, 2);
        user.Password = EncryptionHelper.Encrypt(newPassword);
        await _userRepository.SaveChangesAsync();
        return new(newPassword);
    }

    public async Task ChangePassword(string password, string newPassword)
    {
        var userId = _applicationUser.GetUserId();
        var user = await _userRepository.GetEntityByIdAsync(userId) ?? throw new ArgumentException($"Email is invalid");
        var encryptedPassword = EncryptionHelper.Encrypt(password);

        if(encryptedPassword != user.Password)
        {
            throw new ArgumentException($"Actual password is invalid");
        }

        var encryptedNewPassword = EncryptionHelper.Encrypt(newPassword);
        user.Password = encryptedNewPassword;
        await _userRepository.SaveChangesAsync();
    }
}
