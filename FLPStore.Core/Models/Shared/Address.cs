namespace FLPStore.Core.Models.Shared;

public class Address : ValueObject
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? ZipCode { get; set; }

    public Address() { }

    public Address(string street, string city, string state, string country, string zipcode)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipcode;
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        // Using a yield return statement to return each element one at a time
        yield return Street ?? string.Empty;
        yield return City ?? string.Empty;
        yield return State ?? string.Empty;
        yield return Country ?? string.Empty;
        yield return ZipCode ?? string.Empty;
    }
}
