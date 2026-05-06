using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;
using Love4AnimalsApi.Controllers;

namespace Love4AnimalsApi.Services;

public class PostService : IPostService
{
    private readonly IPostRepository _repository;

    public PostService(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetPostDto>> GetPostsAsync()
    {
        var posts = await _repository.GetAllAsync();
        return posts.Select(p => new GetPostDto
        {
            Id = p.Id,
            Title = p.Title,
            Content = p.Content,
            CampaignId = p.CampaignId,
            ImageUrl = p.ImageUrl
        });
    }

    public async Task<GetPostDto?> GetPostAsync(int id)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post == null) return null;

        return new GetPostDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            CampaignId = post.CampaignId,
            ImageUrl = post.ImageUrl
        };
    }

    public async Task<GetPostDto?> CreatePostAsync(CreatePostDto postDto)
    {
        var post = new Post
        {
            Title = postDto.Title,
            Content = postDto.Content,
            CampaignId = postDto.CampaignId,
            ImageUrl = postDto.ImageUrl
        };

        var result = await _repository.AddAsync(post);
        if (result == null) return null;

        return new GetPostDto
        {
            Id = result.Id,
            Title = result.Title,
            Content = result.Content,
            CampaignId = result.CampaignId,
            ImageUrl = result.ImageUrl
        };
    }

    public async Task<GetPostDto?> UpdatePostAsync(int id, UpdatePostDto postDto)
    {
        var post = new Post
        {
            Title = postDto.Title,
            Content = postDto.Content,
            CampaignId = postDto.CampaignId,
            ImageUrl = postDto.ImageUrl
        };

        var result = await _repository.UpdateAsync(id, post);
        if (result == null) return null;

        return new GetPostDto
        {
            Id = result.Id,
            Title = result.Title,
            Content = result.Content,
            CampaignId = result.CampaignId,
            ImageUrl = result.ImageUrl
        };
    }

    public async Task DeletePostAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}