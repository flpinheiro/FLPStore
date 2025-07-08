using FLPStore.Core.DTOs.Requests;
using FLPStore.Core.Models.OrderAggregates;
using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Core.Models.UserAggragates;

namespace FLPStore.Core.Interfaces.Repositories;

public interface IUserRepository
{
    void Create(AppUser user);
    void Update(AppUser user);
    Task<AppUser> GetUserAsync(Guid id, CancellationToken cancellationToken);
}

public interface IOrderRepository
{
    void Create(Order order);
    Task<Order> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetAsync(Guid userId, IPaginateRequest request, CancellationToken cancellationToken);
}

public interface IProductRepository
{
    Task<Product> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Product>> GetAsync(IPaginateRequest request, CancellationToken cancellationToken);
    void Create(Product product);
    void Delete(Product product);
    void Update(Product product);
}
