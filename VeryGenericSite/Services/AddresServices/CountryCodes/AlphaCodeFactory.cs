using Microsoft.CodeAnalysis.CSharp.Syntax;

using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces;
using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes
{
    public class AlphaCodeFactory : IAlphaCodeFactory<IsoAlphaCodes>
    {
        public IsoAlphaCodes Create(string country, ICountryCodeValidator validator)
        {
            var r = validator.isValidCountry(country);
            if(r is not null)
            {
                return new
            }
            //i guess this should be somehow called from the config
            return new IsoAlphaCodes("000".ToCharArray(), "000".ToCharArray(), 0, "000");
        }
        public AlphaCodeFactory(ICountryCodeValidator validator)
        {

        }
    }
}
