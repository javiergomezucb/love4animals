using Microsoft.AspNetCore.Mvc;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Controllers;

[ApiController]
[Route("v1/comments")]
public class CommentController : ControllerBase
{
    // ✅ CORREGIDO: Acoplado formalmente a la capa de servicios
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCommentDto>))]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _commentService.GetCommentsAsync();
        return Ok(comments);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCommentDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var comment = await _commentService.GetCommentByIdAsync(id);
        if (comment == null) return NotFound(new { message = "Comentario no encontrado" });
        return Ok(comment);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetCommentDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateCommentDto dto)
    {
        var result = await _commentService.CreateCommentAsync(dto);

        if (result == null)
        {
            return BadRequest(new { message = "No se pudo crear el comentario. Verifique que el post exista." });
        }

        return Created($"/v1/comments/{result.Id}", result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _commentService.DeleteCommentAsync(id);
        if (!deleted) return NotFound(new { message = "Comentario no encontrado" });

        return Ok(new { message = "Comentario eliminado correctamente" });
    }
}