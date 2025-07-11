namespace FLPStore.CrossCutting.DTOs.Requests.Users;

public interface ICreateUserRequest
{
    string? FirstName { get; init; }
    string? LastName { get; init; }
    string? Email { get; init; }
    string? Password { get; init; }
    string? ConfirmPassword { get; init; }
    DateTime BirthDate { get; init; }
}
