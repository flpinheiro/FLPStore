using FLPStore.CrossCutting.DTOs.Responses;

namespace FLPStore.Domain.DTOs.Responses.Products;

public record PaginatedProductResponse : IPaginatedProductResponse
{
    public Guid Id { get; init; }
    public string? Title { get; init; }
    public decimal Price { get; init; }
    public bool IsOnStock { get; init; }
}
