using Microsoft.AspNetCore.Mvc;
using Love4AnimalsApi.Models;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Dtos;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Controllers;

[ApiController]
[Route("v1/comments")]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository _repository;

    public CommentController(ICommentRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _repository.GetAllAsync();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var comment = await _repository.GetByIdAsync(id);
        if (comment == null) return NotFound();
        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentDto dto)
    {
        var newComment = new Comment
        {
            Content = dto.Content,
            PostId = dto.PostId,
            AuthorName = dto.AuthorName
        };

        var result = await _repository.AddAsync(newComment);

        if (result == null)
        {
            return BadRequest(new { message = "No se pudo crear el comentario. Verifique que el post exista." });
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted) return NotFound();

        return Ok(new { message = "Comentario eliminado correctamente" });
    }
}