using Love4AnimalsApi.Models;
public interface IUserRepository
{
    Task<User?> GetUserAsync(int id);
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}