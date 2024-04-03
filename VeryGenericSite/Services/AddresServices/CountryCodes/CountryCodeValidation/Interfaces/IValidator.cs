using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces
{
    public interface ICountryCodeValidator : IReadOnlyDictionary<string, IAlphaCountryCode>, IValidateCountryCode<IAlphaCountryCode>
    {
    }
}
