
using System.Threading.Tasks; // Necesario para Task
using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces; // Usamos la interfaz para mayor profesionalismo
using Love4AnimalsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Love4AnimalsApi.Controllers;

[ApiController]
[Route("v1/donations")]
public class DonationController : ControllerBase
{
    private readonly IDonationRepository _repository;

    public DonationController(IDonationRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        // Usamos await y el nuevo nombre GetAllAsync
        var donations = await _repository.GetAllAsync();
        return Ok(donations);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateDonationDto dto)
    {
        var newDonation = new Donation(0, dto.Amount, dto.CampaignId, dto.DonorName);

        // Usamos await y el nombre AddAsync
        var result = await _repository.AddAsync(newDonation);

        if (result == null)
        {
            return BadRequest(new {
                success = false,
                message = "No se pudo realizar la donación: La campaña no existe."
            });
        }

        return Ok(new {
            success = true,
            message = "¡Donación recibida! Gracias por apoyar a los animales.",
            data = result
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        // Usamos await y el nombre DeleteAsync
        var deleted = await _repository.DeleteAsync(id);
        if (!deleted)
            return NotFound(new { success = false, message = "Donación no encontrada" });

        return Ok(new { success = true, message = "Registro de donación eliminado" });
    }
}