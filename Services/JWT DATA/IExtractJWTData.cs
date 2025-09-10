namespace Urbs.Services.ExtractJWTData;

public interface IExtractJWTData
{
    Task<Guid> GetUserGuid(HttpContext context);
    Task<int> GetUserSubscriptionID(HttpContext context);
    Task<string> GetUserUsername(HttpContext context);

}