namespace AlsetLibrary
{
    public class Magazine
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileUrl { get; set; }
        public int ResearcherId { get; set; }
        public Researcher Researcher { get; set; }
    }
}