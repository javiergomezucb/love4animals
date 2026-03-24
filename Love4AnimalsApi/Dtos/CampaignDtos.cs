namespace Love4AnimalsApi.Dtos
{
    public class CreateCampaignDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
    }

    public class GetCampaignDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}