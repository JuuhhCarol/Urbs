namespace Urbs.Models;

public class User
{
    public Guid UserId { get; set; }
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Tour Tour { get; set; }
    public Point Point { get; set; }
    ICollection<Tour> Tours { get; set; }

}