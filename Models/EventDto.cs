namespace RaceDay.MVC.Models
{
    public class EventDto
    {
        public int EventId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string EventType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public decimal DistanceKm { get; set; }
        public string? BannerUrl { get; set; }
        public string OrganiserName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}