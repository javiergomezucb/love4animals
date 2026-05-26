namespace Love4AnimalsApi.Controllers; // Asegúrate de que el namespace coincida con tu carpeta

public class GetPostDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CampaignId { get; set; }
    public string? ImageUrl { get; set; } 
}

public class CreatePostDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CampaignId { get; set; }
    public string? ImageUrl { get; set; }
}

public class UpdatePostDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public int CampaignId { get; set; }
    public string? ImageUrl { get; set; }
}