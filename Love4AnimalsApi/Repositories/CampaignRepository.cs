using Love4AnimalsApi.Data;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Love4AnimalsApi.Repositories;

public class CampaignRepository : ICampaignRepository
{
    private readonly AppDbContext _context;

    public CampaignRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Campaign>> GetAllAsync()
        => await _context.Campaigns.ToListAsync();

    public async Task<Campaign?> GetByIdAsync(int id)
        => await _context.Campaigns.FindAsync(id);

    // Implementamos GetCampaignAsync (es lo mismo que GetByIdAsync)
    public async Task<Campaign?> GetCampaignAsync(int id)
        => await _context.Campaigns.FindAsync(id);

    public async Task<Campaign?> AddAsync(Campaign campaign)
    {
        await _context.Campaigns.AddAsync(campaign);
        await _context.SaveChangesAsync();
        return campaign;
    }

    // Lógica para sumar fondos a la campaña automáticamente
    public async Task<bool> CollectFundsAsync(int campaignId, decimal amount)
    {
        var campaign = await _context.Campaigns.FindAsync(campaignId);
        if (campaign == null) return false;

        campaign.AmountCollected += amount; // Sumamos la donación al total
        await _context.SaveChangesAsync();
        return true;
    }
}