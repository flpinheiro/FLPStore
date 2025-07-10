using AutoMapper;
using FLPStore.Core.DTOs.Response;
using FLPStore.Core.Interfaces;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.Requests.Products;
using FLPStore.Domain.Responses.Products;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FLPStore.Domain.Handlers.Products;

public class GetPaginatedProductHandler(ILogger<GetPaginatedProductHandler> logger, IUnitOfWork unit, IMapper mapper) : IRequestHandler<GetPaginatedProductRequest, IPaginatedBaseResponse<IEnumerable<PaginatedProductResponse>>>
{
    public async Task<IPaginatedBaseResponse<IEnumerable<PaginatedProductResponse>>> Handle(GetPaginatedProductRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        logger.LogInformation("Handling GetPaginatedProductRequest");

        var products = await unit.Products.GetPaginatedAsync(request, cancellationToken);

        var pagination = await unit.Products.CountAsync(request, cancellationToken);

        var response = mapper.Map<IEnumerable<PaginatedProductResponse>>(products);

        return new PaginatedBaseResponse<IEnumerable<PaginatedProductResponse>>(response, pagination);
    }
}
