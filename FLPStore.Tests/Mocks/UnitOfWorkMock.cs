using FLPStore.Core.Interfaces;
using FLPStore.Core.Interfaces.Repositories;
using FLPStore.Core.Interfaces.Services;
using Moq;

namespace FLPStore.Tests.Mocks;

internal class UnitOfWorkMock : IDisposable
{
    private bool disposedValue;

    public IUnitOfWork Object => Mock.Object;
    private readonly Mock<IUnitOfWork> Mock;
    public UnitOfWorkMock()
    {
        Mock = new Mock<IUnitOfWork>(MockBehavior.Strict);
    }

    #region Mockers
    public UnitOfWorkMock WithProductRepository(IProductRepository productRepository)
    {
        Mock.Setup(x => x.Products).Returns(productRepository);
        return this;
    }
    public UnitOfWorkMock WithOrderRepository(IOrderRepository orderRepository)
    {
        Mock.Setup(x => x.Orders).Returns(orderRepository);
        return this;
    }
    public UnitOfWorkMock WithUserRepository(IUserRepository userRepository)
    {
        Mock.Setup(x => x.Users).Returns(userRepository);
        return this;
    }
    public UnitOfWorkMock WithIdentityService(IIdentityService jwtService)
    {
        Mock.Setup(x => x.IdentityService).Returns(jwtService);
        return this;
    }
    #endregion

    #region Setupers
    public UnitOfWorkMock SetupBeginTransactionAsync()
    {
        Mock.Setup(x => x.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        return this;
    }
    public UnitOfWorkMock SetupBeginTransactionAsync<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.BeginTransactionAsync(It.IsAny<CancellationToken>()))
            .Throws<TException>();
        return this;
    }

    public UnitOfWorkMock VerifyBeginTransactionAsync(Times times)
    {
        Mock.Verify(x => x.BeginTransactionAsync(It.IsAny<CancellationToken>()), times);
        return this;
    }
    public UnitOfWorkMock SetupCommitTransactionAsync()
    {
        Mock.Setup(x => x.CommitTransactionAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        return this;
    }
    public UnitOfWorkMock SetupCommitTransactionAsync<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.CommitTransactionAsync(It.IsAny<CancellationToken>()))
            .Throws<TException>();
        return this;
    }

    public UnitOfWorkMock VerifyCommitTransactionAsync(Times times)
    {
        Mock.Verify(x => x.CommitTransactionAsync(It.IsAny<CancellationToken>()), times);
        return this;
    }
    public UnitOfWorkMock SetupRollbackTransactionAsync()
    {
        Mock.Setup(x => x.RollbackTransactionAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask)
            .Verifiable();
        return this;
    }
    public UnitOfWorkMock SetupRollbackTransactionAsync<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.RollbackTransactionAsync(It.IsAny<CancellationToken>()))
            .Throws<TException>();
        return this;
    }
    public UnitOfWorkMock VerifyRollBackTransactionAsync(Times times)
    {
        Mock.Verify(x => x.RollbackTransactionAsync(It.IsAny<CancellationToken>()), times);
        return this;
    }
    public UnitOfWorkMock SetupSaveChangesAsync(int result = 1)
    {
        Mock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(result).Verifiable();
        return this;
    }
    public UnitOfWorkMock SetupSaveChangesAsync<TException>()
        where TException : Exception, new()
    {
        Mock.Setup(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .Throws<TException>();
        return this;
    }
    public UnitOfWorkMock VerifySaveChangesAsync(Times times)
    {
        Mock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), times);
        return this;
    }
    #endregion

    #region Dipose
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                Mock?.Object?.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~UnitOfWorkMock()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    #endregion
}
