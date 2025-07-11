namespace FLPStore.CrossCutting.DTOs.Responses;

public interface IUserResponse
{
    string? FirstName { get; init; }
    string? LastName { get; init; }
    Guid Id { get; init; }
    string? Email { get; init; }
}

public interface ILoginUserResponse : IUserResponse
{
    string? Token { get; set; }
}
