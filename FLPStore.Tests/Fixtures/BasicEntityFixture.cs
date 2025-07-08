using Bogus;
using FLPStore.Core.Models.Shared;

namespace FLPStore.Tests.Fixtures;

internal class BasicEntityFixture<TClass> : BasicFixture<TClass>
    where TClass : BasicEntity
{
    public BasicEntityFixture() : base()
    {
        Faker.RuleFor(x => x.Id, x => x.Random.Uuid());
    }
    public BasicEntityFixture<TClass> WithId(Guid id)
    {
        Faker.RuleFor(x => x.Id, id);
        return this;
    }
}
