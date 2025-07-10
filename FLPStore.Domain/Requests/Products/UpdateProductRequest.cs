using FLPStore.CrossCutting.DTOs.Requests.Products;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.Responses.Products;
using MediatR;

namespace FLPStore.Domain.Requests.Products;

public record UpdateProductRequest : IRequest<IBaseResponse<ProductResponse>>, IUpdateProductRequest
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
}
