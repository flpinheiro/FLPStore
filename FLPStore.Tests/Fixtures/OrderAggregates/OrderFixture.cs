using FLPStore.Core.Models.OrderAggregates;
using FLPStore.Core.Models.Shared;
using FLPStore.Core.Models.UserAggragates;
using FLPStore.Tests.Fixtures.Shared;
using FLPStore.Tests.Fixtures.UserAggragates;

namespace FLPStore.Tests.Fixtures.OrderAggregates;

internal class OrderFixture : BasicEntityFixture<Order>
{
    public OrderFixture()
    {
        var user = new AppUserFixture().Generate();
        var address = new AddressFixture().Generate();
        var products = new OrderProductFixture().Generate(1, 5);
        Faker
            .RuleFor(x => x.User, user)
            .RuleFor(x => x.UserId, (Xunit, context) => context.User?.Id ?? Xunit.Random.Uuid())
            .RuleFor(x => x.ShippingAddress, (faker, context) => context.User?.Addresses.First() ?? address)
            .RuleFor(x => x.Products, products)
            .CustomInstantiator(faker => new Order(user.ShoppingCart, user.Addresses.First()));
    }

    public OrderFixture WithUser(AppUser user)
    {
        Faker
            .RuleFor(x => x.User, user)
            .RuleFor(x => x.UserId, user.Id);
        return this;
    }
    public OrderFixture WithAddress(Address address)
    {
        Faker
            .RuleFor(x => x.ShippingAddress, address);
        return this;
    }
    public OrderFixture WithProducts(ICollection<OrderProduct> products)
    {
        Faker
            .RuleFor(x => x.Products, products);
        return this;
    }
}
