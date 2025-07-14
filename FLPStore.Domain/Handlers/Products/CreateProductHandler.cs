using AutoMapper;
using FLPStore.Core.Interfaces;
using FLPStore.Core.Models.ProductAggregates;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.DTOs.Requests.Products;
using FLPStore.Domain.DTOs.Responses;
using FLPStore.Domain.DTOs.Responses.Products;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FLPStore.Domain.Handlers.Products;

public class CreateProductHandler(ILogger<CreateProductHandler> logger, IUnitOfWork unit, IMapper mapper) : IRequestHandler<CreateProductRequest, IBaseResponse<IProductResponse>>
{
    public async Task<IBaseResponse<IProductResponse>> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        logger.LogInformation("Handling CreateProductRequest");

        try
        {
            await unit.BeginTransactionAsync(cancellationToken);

            var productEntity = mapper.Map<Product>(request);

            unit.Products.Add(productEntity);

            await unit.SaveChangesAsync(cancellationToken);

            await unit.CommitTransactionAsync(cancellationToken);

            var response = mapper.Map<ProductResponse>(productEntity);

            return new BaseResponse<ProductResponse>(response);
        }
        catch (Exception ex)
        {
            logger.LogInformation(ex, "Create Product rollback: {request}", request);
            await unit.RollbackTransactionAsync(cancellationToken);
            return new BaseResponse<ProductResponse>(false, "An error occurred while creating the product.");
        }
    }
}
