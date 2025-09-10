using Urbs.Models;
using Urbs.Services.ExtractJWTData;

namespace Urbs.Services.ExtractJWTData;

public class EFExtractJWTData(UrbsDbContext ctx) : IExtractJWTData
{
    public Task<Guid> GetUserGuid(HttpContext context)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetUserSubscriptionID(HttpContext context)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetUserUsername(HttpContext context)
    {
        throw new NotImplementedException();
    }
}