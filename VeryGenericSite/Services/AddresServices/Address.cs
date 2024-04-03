using System.Drawing.Text;

using VeryGenericSite.Services.AddresServices;
using VeryGenericSite.Services.AddresServices.CountryCodes;
using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation;

using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces;

namespace VeryGenericSite.Services.AddresServices
{
    class Address
    {
        IValidateCountryCodeFactory<ICountryCodeValidator> countryCodeFactory;
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        private int? _countryCode;
        public int? CountryCode
        {
            get
            {
                return _countryCode;
            }
            private set
            {
                _countryCode = value;
            }
        }
        public async Task<int?> getValidator()
        {
            try
            {
                var result = await countryCodeFactory.GetValidator();
                var alphanum = result.isValidCountry(Country)!.Value.Value.GetAlphaNumeric();
                _countryCode = alphanum;
                return alphanum;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n", ex.InnerException + "\n", ex.StackTrace + "\n", ex.Source + "\n");
            }
            return null;
        }
        public Address(IValidateCountryCodeFactory<IValidator> facotry)
        {
            countryCodeFactory = facotry;
        }
    }
}
