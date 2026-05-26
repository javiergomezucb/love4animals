using Love4AnimalsApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Interfaces;

public interface ICommentService
{
    Task<IEnumerable<GetCommentDto>> GetCommentsAsync();
    Task<GetCommentDto?> GetCommentByIdAsync(int id);
    Task<GetCommentDto?> CreateCommentAsync(CreateCommentDto dto);
    Task<bool> DeleteCommentAsync(int id);
}