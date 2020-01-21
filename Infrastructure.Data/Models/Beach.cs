namespace Infrastructure.Data.Models
{
    public class Beach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public Flag Flag { get; set; }
    }
}
