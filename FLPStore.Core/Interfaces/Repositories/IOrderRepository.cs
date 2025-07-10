using FLPStore.Core.Models.OrderAggregates;
using FLPStore.CrossCutting.DTOs.Requests;

namespace FLPStore.Core.Interfaces.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Task<Order> GetAsync(Guid id, CancellationToken cancellationToken);
    Task<IEnumerable<Order>> GetAsync(Guid userId, IPaginateRequest request, CancellationToken cancellationToken);
}
