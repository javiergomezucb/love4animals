using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Interfaces;

public interface ICampaignRepository
{
    Task<IEnumerable<Campaign>> GetAllAsync();
    Task<Campaign?> GetByIdAsync(int id); // Para el controlador
    Task<Campaign?> GetCampaignAsync(int id); // 👈 El que pide DonationRepository
    Task<Campaign?> AddAsync(Campaign campaign);
    Task<bool> CollectFundsAsync(int campaignId, decimal amount); // 👈 El que suma el dinero
}