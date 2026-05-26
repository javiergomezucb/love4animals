using Love4AnimalsApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Interfaces;

public interface IUserService
{
    Task<IEnumerable<GetUserDto>> GetUsersAsync();
    Task<GetUserDto?> GetUserAsync(int id);
    Task<GetUserDto> CreateUserAsync(CreateUserDto userDto);
    Task<GetUserDto> UpdateUserAsync(int id, UpdateUserDto userDto);
    Task DeleteUserAsync(int id);
    Task<GetUserDto?> RegisterAsync(RegisterDto registerDto);
    Task<GetUserDto?> LoginAsync(LoginDto loginDto);
}
