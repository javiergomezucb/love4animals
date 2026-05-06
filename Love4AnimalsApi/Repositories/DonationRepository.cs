using Microsoft.EntityFrameworkCore;
using Love4AnimalsApi.Data;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Repositories;

public class DonationRepository : IDonationRepository
{
    private readonly AppDbContext _context;
    private readonly ICampaignRepository _campaignRepository;

    public DonationRepository(AppDbContext context, ICampaignRepository campaignRepository)
    {
        _context = context;
        _campaignRepository = campaignRepository;
    }

    // 1. Obtener todas las donaciones registradas en PostgreSQL
    public async Task<IEnumerable<Donation>> GetAllAsync() 
        => await _context.Donations.AsNoTracking().ToListAsync();

    // 2. Buscar una donación específica por su ID
    public async Task<Donation?> GetByIdAsync(int id) 
        => await _context.Donations.FindAsync(id);

    // 3. Registrar una nueva donación y actualizar los fondos de la campaña
    public async Task<Donation?> AddAsync(Donation donation)
    {
        // Validar que la campaña exista antes de permitir la donación
        var campaign = await _campaignRepository.GetCampaignAsync(donation.CampaignId);
        if (campaign == null) return null;

        // Registrar la donación en su propia tabla
        await _context.Donations.AddAsync(donation);

        // Lógica de Negocio: Sumar el dinero a la campaña usando el método asíncrono
        await _campaignRepository.CollectFundsAsync(donation.CampaignId, donation.Amount);

        // Persistencia: Guardar todos los cambios en la base de datos de Podman
        await _context.SaveChangesAsync();

        return donation;
    }

    // 4. Eliminar un registro de donación
    public async Task<bool> DeleteAsync(int id)
    {
        var donation = await _context.Donations.FindAsync(id);
        if (donation == null) return false;

        _context.Donations.Remove(donation);
        await _context.SaveChangesAsync();
        return true;
    }
}