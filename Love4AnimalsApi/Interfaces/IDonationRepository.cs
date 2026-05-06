using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Interfaces;

public interface IDonationRepository
{
    Task<IEnumerable<Donation>> GetAllAsync();
    Task<Donation?> GetByIdAsync(int id);
    Task<Donation?> AddAsync(Donation donation);
    Task<bool> DeleteAsync(int id);
}