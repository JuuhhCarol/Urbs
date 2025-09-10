using Urbs.Services.ExtractJWTData;
using Urbs.Models;
using Urbs.Services.ExtractJWTData;
namespace Urbs.UseCases.CreateTour;

public class CreateTourUseCase(
    UrbsDbContext ctx
)
{
    public async Task<Result<CreateTourResponse>> Do(CreateTourPayload payload)
{
    var Tour = new Tour
    {
        Title = payload.Title,
        Description = payload.Description
    };

    User.Tours.Add(Tour);
    ctx.Tours.Add(Tour);
    await ctx.SaveChangesAsync();

        return Result<CreateTourResponse>.Success(new());
    }
}