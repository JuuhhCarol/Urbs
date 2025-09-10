using Microsoft.AspNetCore.Mvc;
using urbs.UseCases.GetTour;
using Urbs.UseCases.CreateTour;
using Urbs.UseCases.EditTour;
using Urbs.UseCases.GetTour;

namespace Urbs.Endpoints;

public static class TourEndPoints
{
    public static void ConfigureTourEndpoints(this WebApplication app)
    {
        app.MapGet("view-Tour", async (
            [FromServices] GetTourUseCase useCase,
            [FromBody] GetTourPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);

        });

        app.MapPost("createTour", async (
            [FromServices] CreateTourUseCase useCase,
            [FromBody] CreateTourPayload payload) =>
        {
            var result = await useCase.Do(payload);

            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        });

        app.MapPut("edit-Tour/{TourGuid}", (Guid TourGuid) =>
        {

        }).RequireAuthorization();


    }
}