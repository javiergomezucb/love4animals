using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Models;
using Love4AnimalsApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Love4AnimalsApi.Controllers
{
    [ApiController]
    [Route("v1/campaigns")]
    public class CampaignController : ControllerBase
    {
        private readonly CampaignRepository _repository;

        public CampaignController()
        {
            _repository = new CampaignRepository();
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_repository.GetAll());

        [HttpPost]
        public IActionResult Create([FromBody] CreateCampaignDto dto)
        {
            var newCampaign = new Campaign(0, dto.Title!, dto.Description!);
            _repository.Add(newCampaign);
            return Ok("Campaña creada");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateCampaignDto dto)
        {
            var campaign = new Campaign(id, dto.Title!, dto.Description!);
            _repository.Update(campaign);
            return Ok("Campaña actualizada");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok("Campaña eliminada");
        }
    }
}