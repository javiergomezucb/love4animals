using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Controllers;

namespace Love4AnimalsApi.Interfaces;

public interface IPostService
{
    Task<IEnumerable<GetPostDto>> GetPostsAsync();
    Task<GetPostDto?> GetPostAsync(int id);
    Task<GetPostDto?> CreatePostAsync(CreatePostDto postDto);
    Task<GetPostDto?> UpdatePostAsync(int id, UpdatePostDto postDto);
    Task DeletePostAsync(int id);
}