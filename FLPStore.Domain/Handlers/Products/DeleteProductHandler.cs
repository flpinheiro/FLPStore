using AutoMapper;
using FLPStore.Core.Interfaces;
using FLPStore.CrossCutting.DTOs.Responses;
using FLPStore.Domain.DTOs.Requests.Products;
using FLPStore.Domain.DTOs.Responses;
using FLPStore.Domain.DTOs.Responses.Products;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FLPStore.Domain.Handlers.Products;

public class DeleteProductHandler(ILogger<DeleteProductHandler> logger, IUnitOfWork unit, IMapper mapper) : IRequestHandler<DeleteProductRequest, IBaseResponse<IProductResponse>>
{
    public async Task<IBaseResponse<IProductResponse>> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        logger.LogInformation("Handling DeleteProductRequest");

        try
        {
            await unit.BeginTransactionAsync(cancellationToken);
            var product = await unit.Products.GetAsync(request.Id, cancellationToken);
            if (product is null)
            {
                return new BaseResponse<ProductResponse>(false, "product not found");
            }

            unit.Products.Remove(product);

            await unit.SaveChangesAsync(cancellationToken);

            await unit.CommitTransactionAsync(cancellationToken);

            var response = mapper.Map<ProductResponse>(product);

            return new BaseResponse<ProductResponse>(response);
        }
        catch (Exception ex)
        {
            logger.LogInformation(ex, "Delete Product rollback: {request}", request);
            await unit.RollbackTransactionAsync(cancellationToken);
            return new BaseResponse<ProductResponse>(false, "An error occurred while deleting the product.");
        }
    }
}
