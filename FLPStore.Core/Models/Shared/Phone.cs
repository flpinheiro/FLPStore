using FLPStore.CrossCutting.Constants;

namespace FLPStore.Core.Models.Shared;

public class Phone(string countryCode, string? areaCode, string number, PhoneType type = PhoneType.Home) : ValueObject
{

    public string CountryCode { get; private set; } = countryCode;
    public string? AreaCode { get; private set; } = areaCode;
    public string Number { get; private set; } = number;

    public PhoneType Type { get; private set; } = type;

    public Phone(string countryCode, string number, PhoneType type = PhoneType.Home) : this(countryCode, null, number, type) { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        if (AreaCode is not null) yield return AreaCode;
        yield return Number;
    }
}