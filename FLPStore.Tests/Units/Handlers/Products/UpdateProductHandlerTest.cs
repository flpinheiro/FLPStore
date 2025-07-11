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

public class UpdateProductHandlerTest
{
    private readonly Mock<ILogger<UpdateProductHandler>> logger = new();
    private readonly UnitOfWorkMock unit = new();
    private readonly ProductRepositoryMock Products = new();
    private readonly IMapper mapper = MapperStub.GetMapper(new ProductProfile());
    private readonly UpdateProductHandler handler;

    public UpdateProductHandlerTest()
    {
        handler = new UpdateProductHandler(logger.Object, unit.Object, mapper);
        unit.WithProductRepository(Products.Object);
    }
    [Fact]
    public async Task Run_Handler_Async()
    {
        var request = new UpdateProductRequestFixture().Generate();
        var product = new ProductFixture().WithId(request.Id).Generate();

        unit.SetupSaveChangesAsync()
            .SetupBeginTransactionAsync()
            .SetupCommitTransactionAsync()
            .SetupRollbackTransactionAsync();

        Products.SetupEdit().SetupGetAsync(product);

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.True(response.IsSuccess);
        Assert.Empty(response.Messages);

        var data = Assert.IsType<ProductResponse>(response.Data);

        Assert.Equal(data.Title, request.Title);
        Assert.Equal(data.Description, request.Description);
        Assert.Equal(data.Price, request.Price);
        Assert.Equal(data.Id, request.Id);
        Assert.True(data.IsOnStock);

        unit.VerifyBeginTransactionAsync(Times.Once())
            .VerifyCommitTransactionAsync(Times.Once())
            .VerifySaveChangesAsync(Times.Once())
            .VerifyRollBackTransactionAsync(Times.Never());

        Products.VerifyEdit(Times.Once())
            .VerifyGetAsync(Times.Once());
    }

    [Fact]
    public async Task Run_Handler_Excption_Async()
    {
        var request = new UpdateProductRequestFixture().Generate();
        var product = new ProductFixture().WithId(request.Id).Generate();

        unit.SetupSaveChangesAsync()
            .SetupBeginTransactionAsync()
            .SetupCommitTransactionAsync()
            .SetupRollbackTransactionAsync();

        Products.SetupEdit<Exception>().SetupGetAsync(product);

        var response = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(response);
        Assert.False(response.IsSuccess);
        Assert.NotEmpty(response.Messages);
        Assert.Null(response.Data);

        unit.VerifyBeginTransactionAsync(Times.Once())
            .VerifyCommitTransactionAsync(Times.Never())
            .VerifySaveChangesAsync(Times.Never())
            .VerifyRollBackTransactionAsync(Times.Once());

        Products.VerifyEdit(Times.Once()).VerifyGetAsync(Times.Once());
    }
}