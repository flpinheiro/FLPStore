using FLPStore.Core.Models.OrderAggregates;
using FLPStore.Core.Models.ProductAggregates;

namespace FLPStore.Tests.Fixtures.Models.OrderAggregates;

internal class OrderItemFixture: BasicValueObjectFixture<OrderItem>
{
    public OrderItemFixture()
    {
        Faker
            .RuleFor(x => x.ProductId, x => x.Random.Uuid())
            .RuleFor(x => x.Name, x => x.Commerce.ProductName())
            .RuleFor(x => x.UnitValue, x => x.Random.Decimal(1, 100))
            .RuleFor(x => x.Quantity, x => x.Random.Int(1, 10));
    }
    public OrderItemFixture WithProduct(Product product, int quantity)
    {
        Faker
            .CustomInstantiator(X => new OrderItem(product, quantity));
        return this;
    }
}