using Urbs.Models;
namespace Urbs.UseCases.GetTour;

public record GetTourResponse(
    ICollection<Tour> Tours
);