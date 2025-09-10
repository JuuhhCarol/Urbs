using Urbs.Models;

namespace Urbs.Services.Profiles;

public interface IProfilesService
{
    Task<User> FindByLogin(string login);
    Task<Guid> Create(User profile);
}