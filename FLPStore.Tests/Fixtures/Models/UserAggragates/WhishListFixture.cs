using FLPStore.Core.Models.ProductAggregates;
using FLPStore.Core.Models.UserAggragates;

namespace FLPStore.Tests.Fixtures.Models.UserAggragates;

internal class WhishListFixture : BasicValueObjectFixture<WhishList>
{
    public WhishListFixture()
    {
        Faker
            .RuleFor(x => x.Name, x => x.Random.Word())
            .RuleFor(x => x.IsPublic, x => x.Random.Bool())
            .RuleFor(x => x.Items, x => [])
            //.CustomInstantiator(faker => new WhishList(
            //    faker.Random.Word(),
            //    faker.Random.Bool()
            //    ))
            ;
    }

    public WhishListFixture WithName(string name)
    {
        Faker.RuleFor(x => x.Name, name);
        return this;
    }

    public WhishListFixture WithIsPublic(bool isPublic)
    {
        Faker.RuleFor(x => x.IsPublic, isPublic);
        return this;
    }

    //public WhishListFixture WithProducts(ICollection<Product> products)
    //{
    //    Faker.RuleFor(x => x.Items, products);
    //    return this;
    //}
}
