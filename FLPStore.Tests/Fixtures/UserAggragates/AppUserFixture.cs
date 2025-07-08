using FLPStore.Core.Models.Shared;
using FLPStore.Core.Models.UserAggragates;
using FLPStore.Tests.Fixtures.ProductAggregates;
using FLPStore.Tests.Fixtures.Shared;

namespace FLPStore.Tests.Fixtures.UserAggragates;

internal class AppUserFixture: BasicEntityFixture<AppUser>
{
    public AppUserFixture()
    {
        Faker
            .RuleFor(x => x.Addresses, x =>  new AddressFixture().Generate(1,5))
            .RuleFor(x => x.Phones, x => new PhoneFixture().Generate(1,5))
            .RuleFor(x => x.WhishLists, x => new WhishListFixture().Generate(1,5))
            .RuleFor(x => x.ShoppingCart, x => new ShoppingCArtFixture(Generate()).Generate())
            ;
    }
    public AppUserFixture WithAddresses(ICollection<Address> addresses)
    {
        Faker.RuleFor(x => x.Addresses, addresses);
        return this;
    }
    
    public AppUserFixture WithPhones(ICollection<Phone> phones)
    {
        Faker.RuleFor(x => x.Phones, phones);
        return this;
    }
    public AppUserFixture WithWhishLists(ICollection<WhishList> whishLists)
    {
        Faker.RuleFor(x => x.WhishLists, whishLists);
        return this;
    }

}
internal class ShoppingCArtFixture : BasicValueObjectFixture<ShoppingCart>
{
    public ShoppingCArtFixture(AppUser user)
    {
        Faker
            .RuleFor(x => x.Products, x => new ShoppingCartProductFixture().Generate(1, 10))
            .RuleFor(x => x.User, user)
            .RuleFor(x => x.UserId, (Xunit, context) => context.User?.Id);
    }
    public ShoppingCArtFixture WithProducts(ICollection<ShoppingCartProduct> products)
    {
        Faker.RuleFor(x => x.Products, products);
        return this;
    }
}

internal class ShoppingCartProductFixture : BasicValueObjectFixture<ShoppingCartProduct>
{

}
