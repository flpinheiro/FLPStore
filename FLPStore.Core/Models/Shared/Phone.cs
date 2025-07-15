using FLPStore.CrossCutting.Constants;

namespace FLPStore.Core.Models.Shared;

public class Phone(string countryCode, string? areaCode, string number, PhoneType type = PhoneType.Home) : ValueObject
{

    public string CountryCode { get;  set; } = countryCode;
    public string? AreaCode { get;  set; } = areaCode;
    public string Number { get;  set; } = number;

    public PhoneType Type { get;  set; } = type;

    public Phone(string countryCode, string number, PhoneType type = PhoneType.Home) : this(countryCode, null, number, type) { }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CountryCode;
        if (AreaCode is not null) yield return AreaCode;
        yield return Number;
    }
}