using FLPStore.Domain.DTOs.Requests.Products;

namespace FLPStore.Tests.Fixtures.Requests.Products;

internal class DeleteProductRequestFixture : BasicFixture<DeleteProductRequest>
{
    public DeleteProductRequestFixture() : base()
    {
        Faker.RuleFor(x => x.Id, x => x.Random.Guid());
    }
}
