using FLPStore.Domain.DTOs.Requests.Products;

namespace FLPStore.Tests.Fixtures.Requests.Products;

internal class CreateProductRequestFixture : BasicFixture<CreateProductRequest>
{
    public CreateProductRequestFixture() : base()
    {
        Faker.RuleFor(x => x.Title, x => x.Commerce.Product())
            .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
            .RuleFor(x => x.Quantity, x => x.Random.Int(1, 100))
            .RuleFor(x => x.Price, x => x.Random.Decimal());
    }
}
