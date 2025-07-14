using FLPStore.Core.Models.Shared;
using FLPStore.Core.Models.UserAggragates;

namespace FLPStore.Tests.Fixtures.Models.UserAggragates;

internal class AppUserFixture : BasicEntityFixture<AppUser>
{
    public AppUserFixture()
    {
        Faker
            .RuleFor(x => x.FirstName, x => x.Person.FirstName)
            .RuleFor(x => x.LastName, x => x.Person.LastName)
            .RuleFor(x => x.Email, x => Email.Create(x.Person.Email))
            .RuleFor(x => x.Password, x => x.Internet.Password())
            .RuleFor(x => x.Addresses, x => [])
            .RuleFor(x => x.Phones, x => [])
            .RuleFor(x => x.WhishLists, x => [])
            .RuleFor(x => x.ShoppingCart, x => new())
            .RuleFor(x => x.Orders, x => []);
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
    public AppUserFixture WithShoppingCart(ShoppingCart shoppingCart)
    {
        Faker.RuleFor(x => x.ShoppingCart, shoppingCart);
        return this;
    }

}
