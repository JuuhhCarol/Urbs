using System.Drawing;

namespace Urbs.UseCases.GetTour;

public record GetTourPayload(
    string Title,
    string Description,
    ICollection<Point> Points,
    string UserName
);