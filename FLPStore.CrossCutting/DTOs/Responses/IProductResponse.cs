namespace FLPStore.CrossCutting.DTOs.Responses;

public interface IProductResponse
{
    string? Description { get; init; }
    Guid Id { get; init; }
    bool IsOnStock { get; init; }
    decimal Price { get; init; }
    string? Title { get; init; }
}


public interface IPaginatedProductResponse
{
    Guid Id { get; init; }
    string? Title { get; init; }
    decimal Price { get; init; }
    bool IsOnStock { get; init; }
}