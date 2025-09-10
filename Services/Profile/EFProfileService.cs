
using Microsoft.EntityFrameworkCore;
using Urbs.Models;

namespace Urbs.Services.Profiles;

public class EFProfileService(UrbsDbContext ctx) : IProfilesService
{
    public async Task<Guid> Create(User profile)
    {
        ctx.Users.Add(profile);
        await ctx.SaveChangesAsync();
        return profile.UserId;
    }

    public async Task<User> FindByLogin(string login)
    {
        var profile = await ctx.Users.FirstOrDefaultAsync(
            p => p.UserName == login || p.Password == login
        );
        return profile;
    }
}