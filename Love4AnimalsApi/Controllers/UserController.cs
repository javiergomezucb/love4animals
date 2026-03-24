using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Love4AnimalsApi.Controllers
{
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
        public IActionResult GetUser([FromRoute] int Id)
        {
            var user = _userService.GetUser(Id);
            if (user == null) return NotFound("Usuario no encontrado");
            return Ok(user);
        }

        [HttpPost("")]
        public IActionResult Register([FromBody] CreateUserDto userDto)
        {
            _userService.CreateUser(userDto);
            return Ok("Usuario registrado con éxito");
        }
    }
}

