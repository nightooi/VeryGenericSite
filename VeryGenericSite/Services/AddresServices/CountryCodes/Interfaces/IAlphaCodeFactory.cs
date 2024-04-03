using System.Reflection.Metadata.Ecma335;

using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces
{
    public interface IAlphaCodeFactory<T> where T : IAlphaCountryCode
    {
        T Create(string country, ICountryCodeValidator validator);
    }
}
