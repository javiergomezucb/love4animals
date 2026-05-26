using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _repository;

    public CommentService(ICommentRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetCommentDto>> GetCommentsAsync()
    {
        var comments = await _repository.GetAllAsync();
        return comments.Select(c => new GetCommentDto
        {
            Id = c.Id,
            Content = c.Content,
            PostId = c.PostId,
            AuthorName = c.AuthorName
        });
    }

    public async Task<GetCommentDto?> GetCommentByIdAsync(int id)
    {
        var comment = await _repository.GetByIdAsync(id);
        if (comment == null) return null;

        return new GetCommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            PostId = comment.PostId,
            AuthorName = comment.AuthorName
        };
    }

    public async Task<GetCommentDto?> CreateCommentAsync(CreateCommentDto dto)
    {
        var comment = new Comment
        {
            Content = dto.Content,
            PostId = dto.PostId,
            AuthorName = dto.AuthorName
        };

        var result = await _repository.AddAsync(comment);
        if (result == null) return null;

        return new GetCommentDto
        {
            Id = result.Id,
            Content = result.Content,
            PostId = result.PostId,
            AuthorName = result.AuthorName
        };
    }

    public async Task<bool> DeleteCommentAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}