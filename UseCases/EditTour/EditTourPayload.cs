using Urbs.Models;
namespace Urbs.UseCases.EditTour;

public record EditTourPayload(
    Guid TourId,
    Guid UserId,
    Guid PointId,
    Point NewPoint,
    HttpContext HttpContext
);