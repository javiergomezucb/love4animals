using System.Collections.Generic;
using System.Threading.Tasks;
using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Love4AnimalsApi.Controllers;

[ApiController]
[Route("v1/donations")]
public class DonationController : ControllerBase
{
    private readonly IDonationService _donationService;

    public DonationController(IDonationService donationService)
    {
        _donationService = donationService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetDonationDto>))]
    public async Task<IActionResult> GetAll()
    {
        var donations = await _donationService.GetDonationsAsync();
        return Ok(donations);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetDonationDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateDonationDto dto)
    {
        var result = await _donationService.CreateDonationAsync(dto);

        if (result == null)
        {
            return BadRequest(new
            {
                success = false,
                message = "No se pudo realizar la donación: La campaña no existe."
            });
        }

        return Ok(new
        {
            success = true,
            message = "¡Donación recibida! Gracias por apoyar a los animales.",
            data = result
        });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id) // ✅ CORREGIDO: Signature limpia con IActionResult
    {
        var deleted = await _donationService.DeleteDonationAsync(id);
        if (!deleted)
            return NotFound(new { success = false, message = "Donación no encontrada" });

        return Ok(new { success = true, message = "Registro de donación eliminado" });
    }
}