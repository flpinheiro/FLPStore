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

public class GetPaginatedProductHandlerTest
{
    private readonly Mock<ILogger<GetPaginatedProductHandler>> logger = new();
    private readonly UnitOfWorkMock unit = new();
    private readonly ProductRepositoryMock Products = new();
    private readonly IMapper mapper = MapperStub.GetMapper(new ProductProfile());
    private readonly GetPaginatedProductHandler handler;

    public GetPaginatedProductHandlerTest()
    {
        handler = new GetPaginatedProductHandler(logger.Object, unit.Object, mapper);
        unit.WithProductRepository(Products.Object);
    }
    [Fact]
    public async Task Run_Handler_Async()
    {
        var request = new GetPaginatedProductRequestFixture().Generate();
        var products = new ProductFixture().Generate(request.PageSize);

        unit.SetupSaveChangesAsync()
            .SetupBeginTransactionAsync()
            .SetupCommitTransactionAsync()
            .SetupRollbackTransactionAsync();

        Products.SetupGetPaginatedAsync(products).SetupCountAsync(request.PageSize);

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        Assert.Empty(response.Messages);

        var data = Assert.IsType<List<PaginatedProductResponse>>(response.Data);

        Assert.NotNull(data);
        Assert.NotEmpty(data);
        Assert.Equal(request.PageSize, data.Count);
        Assert.Equal(request.PageSize, response.Total);

        unit.VerifyBeginTransactionAsync(Times.Never())
            .VerifyCommitTransactionAsync(Times.Never())
            .VerifySaveChangesAsync(Times.Never())
            .VerifyRollBackTransactionAsync(Times.Never());

        Products.VerifyGetPaginatedAsync(Times.Once())
            .VerifyCountAsync(Times.Once());
    }
}
