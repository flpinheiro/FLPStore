using AutoMapper;
using FLPStore.Domain.Handlers.Products;
using FLPStore.Domain.Profiles;
using FLPStore.Domain.Responses.Products;
using FLPStore.Tests.Fixtures.Models.ProductAggregates;
using FLPStore.Tests.Fixtures.Requests.Products;
using FLPStore.Tests.Mocks;
using FLPStore.Tests.Mocks.Repositories;
using FLPStore.Tests.Stubs;
using Microsoft.Extensions.Logging;
using Moq;

namespace FLPStore.Tests.Units.Handlers.Products;

public class GetProductHandlerTest
{
    private readonly Mock<ILogger<GetProductHandler>> logger = new();
    private readonly UnitOfWorkMock unit = new();
    private readonly ProductRepositoryMock Products = new();
    private readonly IMapper mapper = MapperStub.GetMapper(new ProductProfile());
    private readonly GetProductHandler handler;
    public GetProductHandlerTest()
    {
        handler = new GetProductHandler(logger.Object, unit.Object, mapper);
        unit.WithProductRepository(Products.Object);
    }
    [Fact]
    public async Task Run_Handler_Async()
    {
        var request = new GetProductRequestFixture().Generate();
        var product = new ProductFixture().WithId(request.Id).Generate();

        unit.SetupSaveChangesAsync()
            .SetupBeginTransactionAsync()
            .SetupCommitTransactionAsync()
            .SetupRollbackTransactionAsync();

        Products.SetupGetAsync(product);

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

        unit.VerifyBeginTransactionAsync(Times.Never())
            .VerifyCommitTransactionAsync(Times.Never())
            .VerifySaveChangesAsync(Times.Never())
            .VerifyRollBackTransactionAsync(Times.Never());

        Products.VerifyGetAsync(Times.Once());
    }
}
