namespace Love4AnimalsApi.Models;

public class Donation
{
    public int Id { get; set; }
    public decimal Amount { get; set; } // Cambiado de double a decimal
    public int CampaignId { get; set; }
    public string DonorName { get; set; } = string.Empty;

    // Constructor vacío para EF Core
    public Donation() { }

    // Actualizamos el constructor para recibir decimal
    public Donation(int id, decimal amount, int campaignId, string donorName)
    {
        Id = id;
        Amount = amount;
        CampaignId = campaignId;
        DonorName = donorName;
    }
}