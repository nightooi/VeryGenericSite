using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces;
using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation
{
    public class EnglishValidateCountryCodeFactory<T> : ValidateCountryCodeFactory<T>
        where T : class, ICountryCodeValidator
    {
        public EnglishValidateCountryCodeFactory(
           T validator)
            : base(validator)
        {
        }
    }
}
