using FLPStore.CrossCutting.DTOs.Requests.Users;
using FLPStore.CrossCutting.DTOs.Responses;
using MediatR;

namespace FLPStore.Domain.DTOs.Requests.Users;

public class CreateUserRequest : ICreateUserRequest, IRequest<IBaseResponse<IUserResponse>>
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public string? ConfirmPassword { get; init; }
    public DateTime BirthDate { get; init; }
}

public class LoginUserRequest : ILoginUserRequest, IRequest<IBaseResponse<ILoginUserResponse>>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
