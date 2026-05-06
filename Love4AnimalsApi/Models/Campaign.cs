public class Campaign
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal GoalAmount { get; set; } // Cambiado de double a decimal
    public decimal AmountCollected { get; set; } // Cambiado a decimal

    // Constructor vacío para EF Core
    public Campaign() { }

    public Campaign(int id, string title, string description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
}