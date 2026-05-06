using Love4AnimalsApi.Models;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Dtos;

namespace Love4AnimalsApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserDto?> GetUserAsync(int id)
    {
        var user = await _userRepository.GetUserAsync(id);
        if (user == null) return null;
        
        return new GetUserDto { Id = user.Id, Name = user.Name, Email = user.Email };
    }

    public async Task<GetUserDto> CreateUserAsync(CreateUserDto userDto)
    {
        var newUser = new User(0, userDto.Name, userDto.Email);
        await _userRepository.AddUserAsync(newUser);
        
        return new GetUserDto { Id = newUser.Id, Name = newUser.Name, Email = newUser.Email };
    }

    public async Task<GetUserDto> UpdateUserAsync(int id, UpdateUserDto userDto)
    {
        var user = new User(id, userDto.Name, userDto.Email);
        await _userRepository.UpdateUserAsync(user);
        
        return new GetUserDto { Id = id, Name = user.Name, Email = user.Email };
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.DeleteUserAsync(id);
    }
}