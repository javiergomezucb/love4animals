using Love4AnimalsApi.Models;

namespace Love4AnimalsApi.Repositories
{
    public class CampaignRepository
    {
        private static List<Campaign> _campaigns = new List<Campaign>();

        public CampaignRepository()
        {
            if (_campaigns.Count == 0)
            {
                _campaigns.Add(new Campaign(1, "Rescate Animal", "Ayuda a refugios locales"));
            }
        }

        public List<Campaign> GetAll() => _campaigns;

        public Campaign? GetById(int id) => _campaigns.FirstOrDefault(c => c.Id == id);

        public void Add(Campaign campaign)
        {
            campaign.Id = _campaigns.Count > 0 ? _campaigns.Max(c => c.Id) + 1 : 1;
            _campaigns.Add(campaign);
        }

        public void Update(Campaign campaign)
        {
            var existing = GetById(campaign.Id);
            if (existing != null)
            {
                existing.Title = campaign.Title;
                existing.Description = campaign.Description;
            }
        }

        public void Delete(int id) => _campaigns.RemoveAll(c => c.Id == id);
    }
}