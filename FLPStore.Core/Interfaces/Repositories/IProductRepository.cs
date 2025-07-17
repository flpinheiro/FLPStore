using FLPStore.Core.Models.ProductAggregates;
using FLPStore.CrossCutting.DTOs.Requests;

namespace FLPStore.Core.Interfaces.Repositories;

public interface IProductRepository
{
    Task<Product?> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> GetPaginatedAsync(IPaginateRequest request, CancellationToken cancellationToken);
    Task<int> CountAsync(IPaginateRequest paginateRequest, CancellationToken cancellationToken);
    void Add(Product product);
    void Remove(Product product);
    void Edit(Product product);
}
