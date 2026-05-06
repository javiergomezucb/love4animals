using Love4AnimalsApi.Dtos;

namespace Love4AnimalsApi.Interfaces;

public interface ICampaignService
{
    Task<IEnumerable<GetCampaignDto>> GetCampaignsAsync();
    Task<GetCampaignDto?> GetCampaignAsync(int id);
    Task<GetCampaignDto> CreateCampaignAsync(CreateCampaignDto campaignDto);
}