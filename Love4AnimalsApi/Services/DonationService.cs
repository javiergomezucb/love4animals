using Love4AnimalsApi.Dtos;
using Love4AnimalsApi.Interfaces;
using Love4AnimalsApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Love4AnimalsApi.Services;

public class DonationService : IDonationService
{
    private readonly IDonationRepository _repository;

    public DonationService(IDonationRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<GetDonationDto>> GetDonationsAsync()
    {
        var donations = await _repository.GetAllAsync();
        return donations.Select(d => new GetDonationDto
        {
            Id = d.Id,
            Amount = d.Amount,
            CampaignId = d.CampaignId,
            DonorName = d.DonorName
        });
    }
    public async Task<GetDonationDto?> GetDonationAsync(int id)
    {
        var donation = await _repository.GetByIdAsync(id);
        if (donation == null) return null;

        return new GetDonationDto
        {
            Id = donation.Id,
            Amount = donation.Amount,
            CampaignId = donation.CampaignId,
            DonorName = donation.DonorName
        };
    }

    public async Task<GetDonationDto?> CreateDonationAsync(CreateDonationDto donationDto)
    {
        var donation = new Donation
        {
            Amount = donationDto.Amount,
            CampaignId = donationDto.CampaignId,
            DonorName = donationDto.DonorName
        };
        var result = await _repository.AddAsync(donation);
        if (result == null) return null;

        return new GetDonationDto
        {
            Id = result.Id,
            Amount = result.Amount,
            CampaignId = result.CampaignId,
            DonorName = result.DonorName
        };
    }

    public async Task<bool> DeleteDonationAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}