namespace Love4AnimalsApi.Dtos;

public class CreateDonationDto
{
    public decimal Amount { get; set; }
    public int CampaignId { get; set; }
    public string DonorName { get; set; } = string.Empty;
}

public class GetDonationDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public int CampaignId { get; set; }
    public string DonorName { get; set; } = string.Empty;
}