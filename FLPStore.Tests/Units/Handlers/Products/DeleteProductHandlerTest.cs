using AutoMapper;
using FLPStore.Domain.DTOs.Responses.Products;
using FLPStore.Domain.Handlers.Products;
using FLPStore.Domain.Profiles;
using FLPStore.Tests.Fixtures.Models.ProductAggregates;
using FLPStore.Tests.Fixtures.Requests.Products;
using FLPStore.Tests.Mocks;
using FLPStore.Tests.Mocks.Repositories;
using FLPStore.Tests.Stubs;
using Microsoft.Extensions.Logging;
using Moq;

namespace FLPStore.Tests.Units.Handlers.Products;

public class DeleteProductHandlerTest
{
    private readonly Mock<ILogger<DeleteProductHandler>> logger = new();
    private readonly UnitOfWorkMock unit = new();
    private readonly ProductRepositoryMock Products = new();
    private readonly IMapper mapper = MapperStub.GetMapper(new ProductProfile());
    private readonly DeleteProductHandler handler;
    public DeleteProductHandlerTest()
    {
        handler = new DeleteProductHandler(logger.Object, unit.Object, mapper);
        unit.WithProductRepository(Products.Object);
    }
    [Fact]
    public async Task Run_Handler_Async()
    {
        var request = new DeleteProductRequestFixture().Generate();
        var product = new ProductFixture().WithId(request.Id).Generate();

        unit.SetupSaveChangesAsync()
            .SetupBeginTransactionAsync()
            .SetupCommitTransactionAsync()
            .SetupRollbackTransactionAsync();

        Products.SetupRemove()
            .SetupGetAsync(product);

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        Assert.Empty(response.Messages);

        var data = Assert.IsType<ProductResponse>(response.Data);

        Assert.Equal(data.Title, product.Title);
        Assert.Equal(data.Description, product.Description);
        Assert.Equal(data.Price, product.Price);
        Assert.Equal(data.Id, product.Id);
        Assert.Equal(data.Id, request.Id);
        Assert.True(data.IsOnStock);

        unit.VerifyBeginTransactionAsync(Times.Once())
            .VerifyCommitTransactionAsync(Times.Once())
            .VerifySaveChangesAsync(Times.Once())
            .VerifyRollBackTransactionAsync(Times.Never());

        Products
            .VerifyRemove(Times.Once())
            .VerifyGetAsync(Times.Once());
    }

    [Fact]
    public async Task Run_Handler_Excption_Async()
    {
        var request = new DeleteProductRequestFixture().Generate();
        var product = new ProductFixture().WithId(request.Id).Generate();

        unit.SetupSaveChangesAsync()
            .SetupBeginTransactionAsync()
            .SetupCommitTransactionAsync()
            .SetupRollbackTransactionAsync();

        Products.SetupRemove<Exception>().SetupGetAsync(product);

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
        Assert.NotEmpty(response.Messages);
        Assert.Null(response.Data);

        unit.VerifyBeginTransactionAsync(Times.Once())
            .VerifyCommitTransactionAsync(Times.Never())
            .VerifySaveChangesAsync(Times.Never())
            .VerifyRollBackTransactionAsync(Times.Once());

        Products.VerifyRemove(Times.Once()).VerifyGetAsync(Times.Once());
    }
}
