using FLPStore.CrossCutting.DTOs.Requests.Products;
using FLPStore.CrossCutting.DTOs.Responses;
using MediatR;

namespace FLPStore.Domain.DTOs.Requests.Products;

public record GetProductRequest : IRequest<IBaseResponse<IProductResponse>>, IGetProductRequest
{
    public Guid Id { get; set; }
}
