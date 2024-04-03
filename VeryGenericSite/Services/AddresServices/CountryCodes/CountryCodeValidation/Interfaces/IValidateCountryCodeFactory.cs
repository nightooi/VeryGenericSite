using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces
{
    public interface IValidateCountryCodeFactory<T>
       where T : ICountryCodeValidator
    {
        Task<T> CreateAsync();
    }
}
