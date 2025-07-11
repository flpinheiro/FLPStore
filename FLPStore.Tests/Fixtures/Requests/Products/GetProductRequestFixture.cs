using FLPStore.Domain.Requests.Products;

namespace FLPStore.Tests.Fixtures.Requests.Products;

internal class GetProductRequestFixture : BasicFixture<GetProductRequest>
{
    public GetProductRequestFixture() : base()
    {
        Faker.RuleFor(x => x.Id, x => x.Random.Guid());
    }
}
