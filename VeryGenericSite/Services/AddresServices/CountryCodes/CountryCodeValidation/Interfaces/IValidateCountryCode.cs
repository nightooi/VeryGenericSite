using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces
{
    public interface IValidateCountryCode<T>
    {
        KeyValuePair<string, T>? isValidCountry(string countryName);
        KeyValuePair<string, T>? isValidCountry(int alphaNumeric);
    }
}
