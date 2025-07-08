using FLPStore.Core.Models.Shared;

namespace FLPStore.Tests.Fixtures.Shared;

internal class AddressFixture : BasicValueObjectFixture<Address>
{
    public AddressFixture()
    {
        Faker
            .RuleFor(x => x.Country, Xunit => Xunit.Address.Country())
            .RuleFor(x => x.City, Xunit => Xunit.Address.City())
            .RuleFor(x => x.State, Xunit => Xunit.Address.State())
            .RuleFor(x => x.Street, Xunit => Xunit.Address.StreetAddress())
            .RuleFor(x => x.ZipCode, Xunit => Xunit.Address.ZipCode())
            .CustomInstantiator(faker => new Address(
                faker.Address.StreetName(),
                faker.Address.City(),
                faker.Address.State(),
                faker.Address.Country(),
                faker.Address.ZipCode()));
    }

    public AddressFixture WithStreet(string street)
    {
        Faker.RuleFor(x => x.Street, street);
        return this;
    }
    public AddressFixture WithCity(string city)
    {
        Faker.RuleFor(x => x.City, city);
        return this;
    }
    public AddressFixture WithState(string state)
    {
        Faker.RuleFor(x => x.State, state);
        return this;
    }
    public AddressFixture WithCountry(string country)
    {
        Faker.RuleFor(x => x.Country, country);
        return this;
    }
    public AddressFixture WithZipCode(string zipCode)
    {
        Faker.RuleFor(x => x.ZipCode, zipCode);
        return this;
    }
}
