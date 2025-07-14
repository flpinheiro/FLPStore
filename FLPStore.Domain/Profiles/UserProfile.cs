using FLPStore.Core.Models.UserAggragates;
using FLPStore.Domain.DTOs.Requests.Users;
using FLPStore.Domain.DTOs.Responses.Users;

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
