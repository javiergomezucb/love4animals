using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Interfaces;

public interface IPostRepository
{
    Task<IEnumerable<Post>> GetAllAsync();
    Task<Post?> GetByIdAsync(int id);
    Task<Post?> AddAsync(Post post);
    Task<Post?> UpdateAsync(int id, Post updatedPost);
    Task<bool> DeleteAsync(int id);
}