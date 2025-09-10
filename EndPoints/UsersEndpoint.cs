using Microsoft.AspNetCore.Mvc;
using Urbs.UseCases.Login;

namespace Urbs.Endpoints;


public static class AuthEndPoints
{
    public static void ConfigureAuthEndpoints(this WebApplication app)
    {
        //ok
        app.MapPost("auth", async (
            [FromBody] LoginPayload payload,
            [FromServices] LoginUseCase useCase) =>
        {
            var result = await useCase.Do(payload);
            if (!result.IsSuccess)
                return Results.BadRequest();
            return Results.Ok(result.Data);
        });
    }
}