using FLPStore.Core.Models.UserAggragates;

namespace FLPStore.Core.Interfaces.Repositories;

public interface IUserRepository
{
    void Add(AppUser user);
    void Edit(AppUser user);
    Task<AppUser> GetUserAsync(Guid id, CancellationToken cancellationToken);
}
