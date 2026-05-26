namespace Love4AnimalsApi.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CampaignId { get; set; }
    public string? ImageUrl { get; set; }

    public Post() { }

    public Post(int id, string title, string content, int campaignId, string? imageUrl)
    {
        Id = id;
        Title = title;
        Content = content;
        CampaignId = campaignId;
        ImageUrl = imageUrl;
    }
}