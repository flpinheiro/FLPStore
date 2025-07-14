using AutoMapper;
using FLPStore.Core.Interfaces;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.DTOs.Requests.Products;
using FLPStore.Domain.DTOs.Responses;
using FLPStore.Domain.DTOs.Responses.Products;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FLPStore.Domain.Handlers.Products;

public class GetProductHandler(ILogger<GetProductHandler> logger, IUnitOfWork unit, IMapper mapper) : IRequestHandler<GetProductRequest, IBaseResponse<IProductResponse>>
{
    public async Task<IBaseResponse<IProductResponse>> Handle(GetProductRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        logger.LogInformation("Handling GetProductRequest");

        var product = await unit.Products.GetAsync(request.Id, cancellationToken);

        var response = mapper.Map<ProductResponse>(product);

        return new BaseResponse<ProductResponse>(response);
    }
}
