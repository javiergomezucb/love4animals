using Microsoft.EntityFrameworkCore;
using Love4AnimalsApi.Data;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Repositories;

// IMPORTANTE: Asegúrate de que herede de IPostRepository
public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;
    private readonly ICampaignRepository _campaignRepository;

    public PostRepository(AppDbContext context, ICampaignRepository campaignRepository)
    {
        _context = context;
        _campaignRepository = campaignRepository;
    }

    public async Task<IEnumerable<Post>> GetAllAsync() 
        => await _context.Posts.AsNoTracking().ToListAsync();

    public async Task<Post?> GetByIdAsync(int id) 
        => await _context.Posts.FindAsync(id);

    public async Task<Post?> AddAsync(Post post)
    {
        var campaign = await _campaignRepository.GetCampaignAsync(post.CampaignId);
        if (campaign == null) return null;

        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> UpdateAsync(int id, Post updatedPost)
    {
        var existing = await _context.Posts.FindAsync(id);
        if (existing == null) return null;

        var campaign = await _campaignRepository.GetCampaignAsync(updatedPost.CampaignId);
        if (campaign == null) return null;

        existing.Title = updatedPost.Title;
        existing.Content = updatedPost.Content;
        existing.CampaignId = updatedPost.CampaignId;
        existing.ImageUrl = updatedPost.ImageUrl; 

        await _context.SaveChangesAsync();
        return existing;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post == null) return false;

        _context.Posts.Remove(post);
        await _context.SaveChangesAsync();
        return true;
    }
}