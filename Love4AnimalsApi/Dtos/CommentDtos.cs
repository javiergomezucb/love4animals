namespace Love4AnimalsApi.Dtos;

public class CreateCommentDto
{
    public string Content { get; set; } = string.Empty;
    public int PostId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
}

public class GetCommentDto
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int PostId { get; set; }
    public string AuthorName { get; set; } = string.Empty;
}