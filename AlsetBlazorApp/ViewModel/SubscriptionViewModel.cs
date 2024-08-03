using AlsetLibrary;

namespace AlsetBlazorApp.ViewModel
{
    public class SubscriptionViewModel
    {
        public int Id { get; set; }
        public int ResearcherId { get; set; }
        public int ResearcherSubscribedId { get; set; }

        public Researcher Researcher { get; set; }
        public Researcher ResearcherSubscribed { get; set; }
    }
}
