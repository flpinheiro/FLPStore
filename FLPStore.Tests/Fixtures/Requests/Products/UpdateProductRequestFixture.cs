using FLPStore.Domain.DTOs.Requests.Products;

namespace FLPStore.Tests.Fixtures.Requests.Products;

internal class UpdateProductRequestFixture : BasicFixture<UpdateProductRequest>
{
    public UpdateProductRequestFixture() : base()
    {
        Faker.RuleFor(x => x.Id, x => x.Random.Guid())
            .RuleFor(x => x.Title, x => x.Commerce.Product())
            .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
            .RuleFor(x => x.Price, x => x.Random.Decimal());
    }
}
