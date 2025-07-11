using FLPStore.CrossCutting.DTOs.Requests.Products;
using FLPStore.CrossCutting.DTOs.Responses;
using MediatR;

namespace FLPStore.Domain.Requests.Products;

public record CreateProductRequest : IRequest<IBaseResponse<IProductResponse>>, ICreateProductRequest
{
    public string? Title { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int Quantity { get; set; }
}
