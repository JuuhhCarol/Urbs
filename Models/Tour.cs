namespace Urbs.Models;

public class Tour
{
    public Guid TourId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } 
    public Point Point { get; set; }
    public User User { get; set; }
    ICollection<Point> Points { get; set; }
}