using FLPStore.Core.Models.UserAggragates;

namespace FLPStore.Tests.Fixtures.Models.UserAggragates;

internal class ShoppingCartFixture : BasicValueObjectFixture<ShoppingCart>
{
    public ShoppingCartFixture()
    {
        Faker
            .RuleFor(x => x.Items, x => [])
            .RuleFor(x => x.User, x => null)
            .RuleFor(x => x.UserId, x => x.Random.Uuid());
    }
    public ShoppingCartFixture WithProducts(ICollection<ShoppingCartItem> products)
    {
        Faker.RuleFor(x => x.Items, products);
        return this;
    }
    public ShoppingCartFixture WithUser(AppUser user)
    {
        Faker.RuleFor(x => x.User, user);
        return this;
    }
}
