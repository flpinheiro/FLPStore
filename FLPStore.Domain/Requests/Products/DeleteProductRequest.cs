using FLPStore.Core.DTOs.Response;
using FLPStore.CrossCutting.DTOs.Requests.Products;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.Responses.Products;
using MediatR;

namespace FLPStore.Domain.Requests.Products;

public record DeleteProductRequest : IRequest<IBaseResponse<ProductResponse>>, IDeleteProductRequest
{
    public Guid Id { get; set; }
}