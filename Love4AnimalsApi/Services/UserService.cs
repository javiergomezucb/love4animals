using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<GetUserDto>> GetUsersAsync()
    {
        var users = await _userRepository.GetUsersAsync();
        return users.Select(u => new GetUserDto { Id = u.Id, Name = u.Name, Email = u.Email });
    }

    public async Task<GetUserDto?> GetUserAsync(int id)
    {
        var user = await _userRepository.GetUserAsync(id);
        if (user == null) return null;
        return new GetUserDto { Id = user.Id, Name = user.Name, Email = user.Email };
    }

    public async Task<GetUserDto> CreateUserAsync(CreateUserDto userDto)
    {
        var newUser = new User
        {
            Name = userDto.Name,
            Email = userDto.Email.ToLower(),
            PasswordHash = string.Empty,
            CreatedAt = DateTime.UtcNow
        };
        await _userRepository.AddUserAsync(newUser);
        return new GetUserDto { Id = newUser.Id, Name = newUser.Name, Email = newUser.Email };
    }

    public async Task<GetUserDto> UpdateUserAsync(int id, UpdateUserDto userDto)
    {
        var existingUser = await _userRepository.GetUserAsync(id);
        if (existingUser == null) return new GetUserDto();

        existingUser.Name = userDto.Name;
        existingUser.Email = userDto.Email.ToLower();

        await _userRepository.UpdateUserAsync(existingUser);
        return new GetUserDto { Id = id, Name = existingUser.Name, Email = existingUser.Email };
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);
    }

    public async Task<GetUserDto?> RegisterAsync(RegisterDto registerDto)
    {
        var existingUser = await _userRepository.GetByEmailAsync(registerDto.Email);
        if (existingUser != null) return null;

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerDto.Password, workFactor: 12);

        var user = new User
        {
            Name = registerDto.Name,
            Email = registerDto.Email.ToLower(),
            PasswordHash = hashedPassword,
            CreatedAt = DateTime.UtcNow
        };

        await _userRepository.AddUserAsync(user);

        return new GetUserDto { Id = user.Id, Name = user.Name, Email = user.Email };
    }
    public async Task<GetUserDto?> LoginAsync(LoginDto loginDto)
    {
        var user = await _userRepository.GetByEmailAsync(loginDto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
        {
            return null;
        }
        user.LastLoginAt = DateTime.UtcNow;
        await _userRepository.UpdateUserAsync(user);

        return new GetUserDto { Id = user.Id, Name = user.Name, Email = user.Email };
    }
}