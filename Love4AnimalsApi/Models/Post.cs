namespace Love4AnimalsApi.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CampaignId { get; set; }
    public string? ImageUrl { get; set; }

    // 1. Constructor vacío (OBLIGATORIO para EF Core y para usar llaves { })
    public Post() { }

    // 2. Constructor con parámetros (El que ya tienes)
    public Post(int id, string title, string content, int campaignId, string? imageUrl)
    {
        Id = id;
        Title = title;
        Content = content;
        CampaignId = campaignId;
        ImageUrl = imageUrl;
    }
}