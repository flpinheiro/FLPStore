using AutoMapper;
using FLPStore.Core.DTOs.Response;
using FLPStore.Core.Interfaces;
using FLPStore.Core.Models.ProductAggregates;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.Requests.Products;
using FLPStore.Domain.Responses.Products;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FLPStore.Domain.Handlers.Products;

public class UpdateProductHandler(ILogger<UpdateProductHandler> logger, IUnitOfWork unit, IMapper mapper) : IRequestHandler<UpdateProductRequest, IBaseResponse<IProductResponse>>
{
    public async Task<IBaseResponse<IProductResponse>> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        logger.LogInformation("Handling UpdateProductRequest");

        try
        {
            await unit.BeginTransactionAsync(cancellationToken);
            var product = await unit.Products.GetAsync(request.Id, cancellationToken);
            if (product is null)
            {
                return new BaseResponse<ProductResponse>(false, "product not found");
            }
            UpdateProduct(product, request);
            unit.Products.Edit(product);

            await unit.SaveChangesAsync(cancellationToken);

            await unit.CommitTransactionAsync(cancellationToken);

            var response = mapper.Map<ProductResponse>(product);

            return new BaseResponse<ProductResponse>(response);

        }
        catch (Exception ex)
        {
            logger.LogInformation(ex, "Uppdate Product rollback: {request}", request);
            await unit.RollbackTransactionAsync(cancellationToken);
            return new BaseResponse<ProductResponse>(false, "An error occurred while updating the product.");

        }
    }
    private static void UpdateProduct(Product product, UpdateProductRequest request)
    {
        product.Title = request.Title;
        product.Price = request.Price;
        product.Description = request.Description;
    }
}
