using FLPStore.Core.Models.UserAggragates;
using FLPStore.Domain.Requests.Users;
using FLPStore.Domain.Responses.Users;

namespace FLPStore.Domain.Profiles;

public class UserProfile : AutoMapper.Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, AppUser>();
        CreateMap<AppUser, UserResponse>();
        CreateMap<AppUser, LoginUserResponse>();
    }
}
