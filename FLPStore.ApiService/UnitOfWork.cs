using FLPStore.Core.Interfaces;
using FLPStore.Core.Interfaces.Repositories;
using FLPStore.Core.Interfaces.Services;

namespace FLPStore.ApiService;

public class UnitOfWork : IUnitOfWork
{
    private bool disposedValue;

    public IUserRepository Users => throw new NotImplementedException();

    public IOrderRepository Orders => throw new NotImplementedException();

    public IProductRepository Products => throw new NotImplementedException();

    public IIdentityService IdentityService => throw new NotImplementedException();

    public Task BeginTransactionAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task RollbackTransactionAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~UnitOfWork()
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
}
