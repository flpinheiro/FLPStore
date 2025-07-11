using FLPStore.CrossCutting.DTOs.Responses;

namespace FLPStore.Domain.Responses.Users;

public class UserResponse : IUserResponse
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public Guid Id { get; init; }
    public string? Email { get; init; }
}
public class LoginUserResponse : UserResponse, ILoginUserResponse
{
    public string? Token { get; set; }
}
