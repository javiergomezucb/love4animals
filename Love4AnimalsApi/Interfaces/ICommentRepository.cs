using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Interfaces;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetAllAsync();
    Task<Comment?> GetByIdAsync(int id);
    Task<Comment?> AddAsync(Comment comment);
    Task<bool> DeleteAsync(int id);
}