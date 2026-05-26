using Microsoft.AspNetCore.Mvc;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Dtos;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Controllers;

[ApiController]
[Route("v1/posts")]
public class PostController : ControllerBase
{
    // ✅ CORREGIDO: Acoplado formalmente a la capa de servicios
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetPostDto>))]
    public async Task<IActionResult> GetAll()
    {
        var posts = await _postService.GetPostsAsync();
        return Ok(posts);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPostDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var post = await _postService.GetPostAsync(id);
        if (post == null) return NotFound(new { message = "Post no encontrado" });
        return Ok(post);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetPostDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreatePostDto dto)
    {
        var result = await _postService.CreatePostAsync(dto);

        if (result == null)
        {
            return BadRequest(new { message = "No se pudo crear el post. Verifique que la campaña exista." });
        }

        return Created($"/v1/posts/{result.Id}", result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetPostDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] UpdatePostDto dto)
    {
        var result = await _postService.UpdatePostAsync(id, dto);
        if (result == null) return NotFound(new { message = "Post no encontrado o campaña inválida" });

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var post = await _postService.GetPostAsync(id);
        if (post == null) return NotFound(new { message = "Post no encontrado" });

        await _postService.DeletePostAsync(id);
        return Ok(new { message = "Post eliminado correctamente" });
    }
}