namespace AlsetLibrary
{
    public class Subscription
    {
        public int Id { get; set; }
        public int IdResearcher { get; set; }
        public string Email { get; set; }

        public Researcher Researcher { get; set; }
    }
}