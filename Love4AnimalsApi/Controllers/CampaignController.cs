using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Controllers;

[ApiController]
[Route("v1/campaigns")]
public class CampaignController : ControllerBase
{
    private readonly ICampaignService _campaignService;

    public CampaignController(ICampaignService campaignService)
    {
        _campaignService = campaignService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetCampaignDto>))]
    public async Task<IActionResult> GetAll() 
    {
        var campaigns = await _campaignService.GetCampaignsAsync();
        return Ok(campaigns);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GetCampaignDto))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateCampaignDto dto)
    {

        var result = await _campaignService.CreateCampaignAsync(dto);
        return Created($"/v1/campaigns/{result.Id}", result);
    }
}