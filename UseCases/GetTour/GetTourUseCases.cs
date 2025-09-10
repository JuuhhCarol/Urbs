using Urbs.Models;
using Urbs.UseCases.GetTour;

namespace urbs.UseCases.GetTour;

public class GetTourUseCase(UrbsDbContext ctx)
{
    public async Task<Result<GetTourResponse>> Do(GetTourPayload payload)
    {
        var tour = await ctx.Tours.FirstOrDefaultAsync(t => t.Title == payload.Title);
        
        if (tour == null)
            return Result<GetProfileResponse>.Fail("Tour não encontrado");

        return Result<GetProfileResponse>.Success(new(tour));
    }
}