using Love4AnimalsApi.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Interfaces;

public interface IDonationService
{
    Task<IEnumerable<GetDonationDto>> GetDonationsAsync();
    Task<GetDonationDto?> GetDonationAsync(int id);
    Task<GetDonationDto?> CreateDonationAsync(CreateDonationDto donationDto);
    Task<bool> DeleteDonationAsync(int id);
}