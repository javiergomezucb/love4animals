using Microsoft.EntityFrameworkCore;
using Love4AnimalsApi.Data;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;
    private readonly IPostRepository _postRepository;

    public CommentRepository(AppDbContext context, IPostRepository postRepository)
    {
        _context = context;
        _postRepository = postRepository;
    }

    public async Task<IEnumerable<Comment>> GetAllAsync()
        => await _context.Comments.AsNoTracking().ToListAsync();

    public async Task<Comment?> GetByIdAsync(int id)
        => await _context.Comments.FindAsync(id);

    public async Task<Comment?> AddAsync(Comment comment)
    {
        // AQUÍ ESTABA EL ERROR: Cambiamos GetById por GetByIdAsync y agregamos await
        var post = await _postRepository.GetByIdAsync(comment.PostId);
        if (post == null) return null;

        await _context.Comments.AddAsync(comment);
        await _context.SaveChangesAsync();
        return comment;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null) return false;

        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return true;
    }
}