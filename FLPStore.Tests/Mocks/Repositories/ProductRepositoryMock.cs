using FLPStore.Core.Interfaces.Repositories;
using FLPStore.Core.Models.ProductAggregates;
using FLPStore.CrossCutting.DTOs.Requests;
using Moq;

namespace FLPStore.Tests.Mocks.Repositories;

internal class ProductRepositoryMock
{
    public IProductRepository Object => Mock.Object;
    private readonly Mock<IProductRepository> Mock;
    public ProductRepositoryMock()
    {
        Mock = new Mock<IProductRepository>(MockBehavior.Strict);
    }

    public ProductRepositoryMock SetupGetAsync(Product product)
    {
        Mock.Setup(x => x.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(product)
            .Verifiable();
        return this;
    }
    public ProductRepositoryMock SetupGetAsync<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
           .Throws<TException>();
        return this;
    }
    public ProductRepositoryMock VerifyGetAsync(Times times)
    {
        Mock.Verify(x => x.GetAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()), times);
        return this;
    }
    public ProductRepositoryMock SetupGetPaginatedAsync(IEnumerable<Product> products)
    {
        Mock.Setup(x => x.GetPaginatedAsync(It.IsAny<IPaginateRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(products)
            .Verifiable();
        return this;
    }
    public ProductRepositoryMock SetupGetPaginatedAsync<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.GetPaginatedAsync(It.IsAny<IPaginateRequest>(), It.IsAny<CancellationToken>()))
            .Throws<TException>();
        return this;
    }
    public ProductRepositoryMock VerifyGetPaginatedAsync(Times times)
    {
        Mock.Verify(x => x.GetPaginatedAsync(It.IsAny<IPaginateRequest>(), It.IsAny<CancellationToken>()), times);
        return this;
    }
    public ProductRepositoryMock SetupCountAsync(int count)
    {
        Mock.Setup(x => x.CountAsync(It.IsAny<IPaginateRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(count)
            .Verifiable();
        return this;
    }
    public ProductRepositoryMock SetupCountAsync<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.CountAsync(It.IsAny<IPaginateRequest>(), It.IsAny<CancellationToken>()))
            .Throws<TException>();
        return this;
    }
    public ProductRepositoryMock VerifyCountAsync(Times times)
    {
        Mock.Verify(x => x.CountAsync(It.IsAny<IPaginateRequest>(), It.IsAny<CancellationToken>()), times);
        return this;
    }
    public ProductRepositoryMock SetupAdd()
    {
        Mock.Setup(x => x.Add(It.IsAny<Product>()))
            .Verifiable();
        return this;
    }
    public ProductRepositoryMock SetupAdd<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.Add(It.IsAny<Product>()))
            .Throws<TException>();
        return this;
    }
    public ProductRepositoryMock VerifyAdd(Times times)
    {
        Mock.Verify(x => x.Add(It.IsAny<Product>()), times);
        return this;
    }
    public ProductRepositoryMock SetupRemove()
    {
        Mock.Setup(x => x.Remove(It.IsAny<Product>()))
            .Verifiable();
        return this;
    }
    public ProductRepositoryMock SetupRemove<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.Remove(It.IsAny<Product>()))
            .Throws<TException>();
        return this;
    }
    public ProductRepositoryMock VerifyRemove(Times times)
    {
        Mock.Verify(x => x.Remove(It.IsAny<Product>()), times);
        return this;
    }
    public ProductRepositoryMock SetupEdit()
    {
        Mock.Setup(x => x.Edit(It.IsAny<Product>()))
            .Verifiable();
        return this;
    }
    public ProductRepositoryMock SetupEdit<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.Edit(It.IsAny<Product>()))
            .Throws<TException>();
        return this;
    }
    public ProductRepositoryMock VerifyEdit(Times times)
    {
        Mock.Verify(x => x.Edit(It.IsAny<Product>()), times);
        return this;
    }
}
