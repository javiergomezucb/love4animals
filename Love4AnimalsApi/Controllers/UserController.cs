using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks; // Obligatorio para Async

namespace Love4AnimalsApi.Controllers;

[ApiController]
[Route("v1/users")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetUser([FromRoute] int Id)
    {
        // El nombre debe ser GetUserAsync y llevar await
        var user = await _userService.GetUserAsync(Id);
        if (user == null) return NotFound("Usuario no encontrado");
        return Ok(user);
    }

    [HttpPost("")]
    public async Task<IActionResult> Register([FromBody] CreateUserDto userDto)
    {
        var createdUser = await _userService.CreateUserAsync(userDto);
        return Ok(createdUser);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> UpdateUser(int Id, [FromBody] UpdateUserDto userDto)
    {
        var updatedUser = await _userService.UpdateUserAsync(Id, userDto);
        if (updatedUser == null) return NotFound("Usuario no encontrado");
        return Ok(updatedUser);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteUser(int Id)
    {
        await _userService.DeleteUserAsync(Id);
        return Ok("Usuario eliminado con éxito");
    }
}