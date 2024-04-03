using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation
{
    public interface IValidationCodeFactory
    {
        public static IAlphaCountryCode Create(char[] alpha2, char[] alpha3, int num, string country)
        {
            ValidationCountryCode code = new ValidationCountryCode()
            {
                Alpha2 = alpha2,
                Alpha3 = alpha3,
                Alphanumeric = num,
                Country = country
            };
            return code;
        }
    }


}
