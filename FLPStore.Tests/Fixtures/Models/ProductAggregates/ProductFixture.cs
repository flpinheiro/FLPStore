using FLPStore.Core.Models.ProductAggregates;

namespace FLPStore.Tests.Fixtures.Models.ProductAggregates;

internal class ProductFixture : BasicEntityFixture<Product>
{
    public ProductFixture()
    {
        Faker
            .RuleFor(x => x.Title, x => x.Random.Word())
            .RuleFor(x => x.Description, Xunit => Xunit.Random.Words())
            .RuleFor(x => x.Quantity, Xunit => Xunit.Random.Int(1, 100))
            .RuleFor(x => x.Price, Xunit => Xunit.Random.Decimal(1, 100));
    }
    public ProductFixture WithTitle(string? title)
    {
        Faker.RuleFor(x => x.Title, title);
        return this;
    }
    public ProductFixture WithDescription(string? description)
    {
        Faker.RuleFor(x => x.Description, description);
        return this;
    }
    public ProductFixture WithPrice(decimal price)
    {
        Faker.RuleFor(x => x.Price, price);
        return this;
    }
    public ProductFixture WithQuantity(int quantity)
    {
        Faker.RuleFor(x => x.Quantity, quantity);
        return this;
    }
}
