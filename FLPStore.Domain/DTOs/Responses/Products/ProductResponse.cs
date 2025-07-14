using FLPStore.CrossCutting.DTOs.Responses;

namespace FLPStore.Domain.DTOs.Responses.Products;

public record ProductResponse : IProductResponse
{
    public Guid Id { get; init; }
    public string? Title { get; init; }
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public bool IsOnStock { get; init; }
}
