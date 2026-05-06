using Love4AnimalsApi.Dtos; // <-- ESTO ES LO QUE TE FALTA

namespace Love4AnimalsApi.Interfaces;

public interface IDonationService
{
    Task<IEnumerable<GetDonationDto>> GetDonationsAsync();
    Task<GetDonationDto?> GetDonationAsync(int id);
    Task<GetDonationDto?> CreateDonationAsync(CreateDonationDto donationDto);
}