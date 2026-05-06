using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Services;

public class CampaignService : ICampaignService
{
    private readonly ICampaignRepository _repository;

    public CampaignService(ICampaignRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetCampaignDto>> GetCampaignsAsync()
    {
        var campaigns = await _repository.GetAllAsync(); // 👈 Usamos GetAllAsync del Repo
        return campaigns.Select(c => new GetCampaignDto
        {
            Id = c.Id,
            Title = c.Title,
            Description = c.Description,
            GoalAmount = c.GoalAmount,
            AmountCollected = c.AmountCollected
        });
    }

    public async Task<GetCampaignDto?> GetCampaignAsync(int id)
    {
        var campaign = await _repository.GetByIdAsync(id); // 👈 Usamos GetByIdAsync
        if (campaign == null) return null;

        return new GetCampaignDto
        {
            Id = campaign.Id,
            Title = campaign.Title,
            Description = campaign.Description,
            GoalAmount = campaign.GoalAmount,
            AmountCollected = campaign.AmountCollected
        };
    }

    public async Task<GetCampaignDto> CreateCampaignAsync(CreateCampaignDto campaignDto)
    {
        var campaign = new Campaign
        {
            Title = campaignDto.Title,
            Description = campaignDto.Description,
            GoalAmount = campaignDto.GoalAmount,
            AmountCollected = 0
        };

        var result = await _repository.AddAsync(campaign); // 👈 Usamos AddAsync

        return new GetCampaignDto
        {
            Id = result!.Id,
            Title = result.Title,
            Description = result.Description,
            GoalAmount = result.GoalAmount,
            AmountCollected = result.AmountCollected
        };
    }
}