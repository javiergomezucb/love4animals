using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models; // Asegúrate de que apunte a tus modelos
using Microsoft.AspNetCore.Mvc;

namespace Love4AnimalsApi.Controllers;

[ApiController]
[Route("v1/campaigns")]
public class CampaignController : ControllerBase
{
    // Cambiamos el Service por el Repository para resolver el error de resolución
    private readonly ICampaignRepository _repository;

    public CampaignController(ICampaignRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        var campaigns = await _repository.GetAllAsync();
        return Ok(campaigns);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCampaignDto dto)
    {
        var newCampaign = new Campaign 
        { 
            Title = dto.Title, 
            Description = dto.Description, 
            GoalAmount = dto.GoalAmount,
            AmountCollected = 0 
        };

        var result = await _repository.AddAsync(newCampaign);
        return Ok(result);
    }
}