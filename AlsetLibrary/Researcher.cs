namespace AlsetLibrary
{
    public class Researcher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public ICollection<Subscription> Subscriptions { get; set; }
        public ICollection<Magazine> Magazines { get; set; }
    }
}