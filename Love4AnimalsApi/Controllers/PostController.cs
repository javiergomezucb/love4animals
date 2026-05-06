using Microsoft.AspNetCore.Mvc;
using Love4AnimalsApi.Models;
using Love4AnimalsApi.Interfaces; // Para usar IPostRepository
using Love4AnimalsApi.Dtos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Controllers;

[ApiController]
[Route("v1/posts")]
public class PostController : ControllerBase
{
    private readonly IPostRepository _repository;

    public PostController(IPostRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Usamos await y el nuevo nombre del método
        var posts = await _repository.GetAllAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await _repository.GetByIdAsync(id);
        if (post == null) return NotFound();
        return Ok(post);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostDto dto)
    {
        var newPost = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            CampaignId = dto.CampaignId,
            ImageUrl = dto.ImageUrl
        };

        var result = await _repository.AddAsync(newPost);

        if (result == null)
        {
            return BadRequest(new { message = "No se pudo crear el post. Verifique que la campaña exista." });
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePostDto dto)
    {
        var updatedPost = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            CampaignId = dto.CampaignId,
            ImageUrl = dto.ImageUrl
        };

        var result = await _repository.UpdateAsync(id, updatedPost);

        if (result == null) return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted) return NotFound();

        return Ok(new { message = "Post eliminado correctamente" });
    }
}