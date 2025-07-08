using FLPStore.Core.Constants;
using FLPStore.Core.Models.Shared;

namespace FLPStore.Tests.Fixtures.Shared;

internal class PhoneFixture : BasicValueObjectFixture<Phone>
{
    public PhoneFixture()
    {
        Faker
            .RuleFor(x => x.CountryCode, Xunit => Xunit.Random.Int(1, 100).ToString())
            .RuleFor(x => x.AreaCode, Xunit => Xunit.Random.Int(11, 99).ToString())
            .RuleFor(x => x.Number, Xunit => Xunit.Phone.PhoneNumber())
            .RuleFor(x => x.Type, Xunit => Xunit.PickRandom<PhoneType>())
            .CustomInstantiator(faker => new Phone(
                faker.Random.Int(1, 100).ToString(),
                faker.Random.Int(1, 99).ToString(),
                faker.Phone.PhoneNumber(),
                faker.PickRandom<PhoneType>()));
    }
    public PhoneFixture WithNumber(string number)
    {
        Faker.RuleFor(x => x.Number, number);
        return this;
    }
    public PhoneFixture WithType(PhoneType type)
    {
        Faker.RuleFor(x => x.Type, type);
        return this;
    }
    public PhoneFixture WithCountryCode(string countryCode)
    {
        Faker.RuleFor(x => x.CountryCode, countryCode);
        return this;
    }
    public PhoneFixture WithAreaCode(string areaCode)
    {
        Faker.RuleFor(x => x.AreaCode, areaCode);
        return this;
    }
}
