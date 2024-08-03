using AlsetBlazorApp.Services;
using AlsetLibrary;
using AlsetLibrary.DTO;
using Microsoft.AspNetCore.Components;

namespace AlsetBlazorApp.ViewModel
{
    public class ListResearcherViewModel
    {
        public ListResearcherViewModel(ResearcherService researcherService, SubscriptionService subscriptionService)
        {
            this.ResearcherService = researcherService;
            this.SubscriptionService = subscriptionService;
        }

        public ResearcherService ResearcherService { get; set; }
        public SubscriptionService SubscriptionService { get; set; }
        public string EmailSubcription { get; set; }
        public int IdResearcher { get; set; }

        public List<ResearcherRecord> researcherRecords = new List<ResearcherRecord>();

        public async Task Load()
        {
             researcherRecords = (await ResearcherService.GetResearchersAsync()).ToList();

        }
        public async Task Follow()
        {
            CreateSubscription createSubscription = new CreateSubscription();
            createSubscription.IdResearcher = this.IdResearcher;
            createSubscription.Email = this.EmailSubcription;
            await SubscriptionService.Follow(createSubscription);
        }
        
    }
}
