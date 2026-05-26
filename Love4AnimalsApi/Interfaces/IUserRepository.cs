using Love4AnimalsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task<User?> GetUserAsync(int id);
    Task<User?> GetByEmailAsync(string email);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}
