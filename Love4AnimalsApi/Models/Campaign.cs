namespace Love4AnimalsApi.Models
{
    public class Campaign
    {
        public Campaign(int id, string title, string description)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}