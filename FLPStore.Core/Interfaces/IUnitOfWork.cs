using FLPStore.Core.Interfaces.Repositories;
using FLPStore.Core.Interfaces.Services;

namespace FLPStore.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository Users { get; }
    IOrderRepository Orders { get; }
    IProductRepository Products { get; }

    IJwtService JwtService { get; }

    /// <summary>
    /// Saves all changes made in this unit of work to the database.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Begins a new transaction for this unit of work.
    /// </summary>
    Task BeginTransactionAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Commits the current transaction for this unit of work.
    /// </summary>
    Task CommitTransactionAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Rollback the current transaction for this unit of work.
    /// </summary>
    Task RollbackTransactionAsync(CancellationToken cancellationToken);
}
