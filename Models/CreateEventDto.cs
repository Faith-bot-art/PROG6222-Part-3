using System.ComponentModel.DataAnnotations;

namespace RaceDay.MVC.Models
{
    public class CreateEventDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        [Required]
        public string EventType { get; set; } = "Running";

        [Required]
        public DateTime StartDate { get; set; } = DateTime.Now.AddDays(30);

        [Required]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(30).AddHours(4);

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public decimal DistanceKm { get; set; }
    }
}