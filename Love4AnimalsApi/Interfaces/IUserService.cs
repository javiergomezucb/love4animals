using Love4AnimalsApi.Dtos;

namespace Love4AnimalsApi.Interfaces;

public interface IUserService
{
    Task<GetUserDto?> GetUserAsync(int id);
    Task<GetUserDto> CreateUserAsync(CreateUserDto userDto);
    Task<GetUserDto> UpdateUserAsync(int id, UpdateUserDto userDto);
    Task DeleteUserAsync(int id);
}