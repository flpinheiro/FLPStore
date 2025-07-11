using FLPStore.Core.Models.OrderAggregates;
using FLPStore.Core.Models.Shared;
using FLPStore.Tests.Fixtures.Models.Shared;

namespace FLPStore.Tests.Fixtures.Models.OrderAggregates;

internal class OrderFixture : BasicEntityFixture<Order>
{
    public OrderFixture()
    {
        Faker
            //.RuleFor(x => x.User,x => new())
            .RuleFor(x => x.UserId, x => x.Random.Uuid())
            .RuleFor(x => x.ShippingAddress, x => new AddressFixture().Generate())
            .RuleFor(x => x.Products, [])
            .CustomInstantiator(x => new(
                x.Random.Uuid(),
                0,
                new AddressFixture().Generate(),
                []));
    }

    public OrderFixture WithUser(Guid id)
    {
        Faker
            //.RuleFor(x => x.User, user)
            .RuleFor(x => x.UserId, id);
        return this;
    }
    public OrderFixture WithAddress(Address address)
    {
        Faker
            .RuleFor(x => x.ShippingAddress, address);
        return this;
    }
    public OrderFixture WithProducts(ICollection<OrderItem> products)
    {
        Faker
            .RuleFor(x => x.Products, products);
        return this;
    }
}
