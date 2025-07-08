using Bogus;

namespace FLPStore.Tests.Fixtures;

internal class BasicFixture<TClass>
    where TClass : class
{
    protected Faker<TClass> Faker = new Faker<TClass>()
        .StrictMode(true);

    public TClass Generate()
    {
        return Faker.Generate();
    }

    public IEnumerable<TClass> Generate(int count)
    {
        return Faker.Generate(count);
    }

    public IEnumerable<TClass> Generate(int min, int max)
    {
        var faker = new Faker();
        return Faker.Generate(faker.Random.Int(min, max));
    }
}
