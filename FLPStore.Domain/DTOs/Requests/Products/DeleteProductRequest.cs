using FLPStore.CrossCutting.DTOs.Requests.Products;
using FLPStore.CrossCutting.DTOs.Responses;
using MediatR;

namespace FLPStore.Domain.DTOs.Requests.Products;

public record DeleteProductRequest : IRequest<IBaseResponse<IProductResponse>>, IDeleteProductRequest
{
    public Guid Id { get; set; }
}