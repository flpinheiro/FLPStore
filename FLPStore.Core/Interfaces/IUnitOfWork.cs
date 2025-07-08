using FLPStore.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLPStore.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository User { get; }
    IOrderRepository Order { get; }
    IProductRepository Product { get; }

    /// <summary>
    /// Saves all changes made in this unit of work to the database.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveAsync(CancellationToken cancellationToken);
    /// <summary>
    /// Begins a new transaction for this unit of work.
    /// </summary>
    void BeginTransaction(CancellationToken cancellationToken);
    /// <summary>
    /// Commits the current transaction for this unit of work.
    /// </summary>
    void CommitTransaction(CancellationToken cancellationToken);
    /// <summary>
    /// Rolls back the current transaction for this unit of work.
    /// </summary>
    void RollbackTransaction();
}
