public class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int PostId { get; set; }
    public string AuthorName { get; set; } = string.Empty;

    public Comment() { } // Constructor vacío indispensable
}