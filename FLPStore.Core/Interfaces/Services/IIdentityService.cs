using FLPStore.CrossCutting.DTOs.Requests.Users;

namespace FLPStore.Core.Interfaces.Services;

public interface IIdentityService
{
    string GenerateToken(ITokenUserRequest user);
    Task CreateUserAsync(ICreateUserRequest request, CancellationToken cancellationToken);
    Task LoginUserAsync(ILoginUserRequest request, CancellationToken cancellationToken);

}
