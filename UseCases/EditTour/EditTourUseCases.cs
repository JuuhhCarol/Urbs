using Urbs.Models;
using Urbs.Services.ExtractJWTData;
using Urbs.Services.JWT;


namespace Urbs.UseCases.EditTour;

public class EditTourUseCase(
    IExtractJWTData extractJWTData,
    UrbsDbContext ctx
)
{
    public async Task<Result<EditTourResponse>> Do(EditTourPayload payload)
    {
        var TourId = payload.TourId;
        var Tour = await ctx.Tours.FindAsync(TourId);

        var PointId = payload.PointId;
        var Point = await ctx.Points.FindAsync(PointId);

        var UserId = await extractJWTData.GetUserGuid(payload.HttpContext);
        var User = await ctx.Users.FindAsync(UserId);

        if (User.Tour = payload.NewPoint)
            return Result<EditTourResponse>.Success(null);
    }
}