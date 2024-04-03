using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

using System.Collections;
using System.Diagnostics.CodeAnalysis;

using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces;
using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation
{
    public class ValidateCountryCode : ICountryCodeValidator
    {
        private Dictionary<string, IAlphaCountryCode> di { get; init; }

        public IAlphaCountryCode this[string key] => ((IReadOnlyDictionary<string, IAlphaCountryCode>)di)[key];

        public IEnumerable<string> Keys => ((IReadOnlyDictionary<string, IAlphaCountryCode>)di).Keys;

        public IEnumerable<IAlphaCountryCode> Values => ((IReadOnlyDictionary<string, IAlphaCountryCode>)di).Values;

        public int Count => ((IReadOnlyCollection<KeyValuePair<string, IAlphaCountryCode>>)di).Count;

        public bool ContainsKey(string key)
        {
            return ((IReadOnlyDictionary<string, IAlphaCountryCode>)di).ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<string, IAlphaCountryCode>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, IAlphaCountryCode>>)di).GetEnumerator();
        }

        public KeyValuePair<string, IAlphaCountryCode>? isValidCountry(string countryName)
        {
            if (countryName is null) return null;
            IAlphaCountryCode code;
            if (countryName.Length > 3)
            {
                return TryGetValue(countryName, out code) ?
                    new KeyValuePair<string, IAlphaCountryCode>(countryName, code) :
                    null;
            }
            else
            {
                var val = Values.FirstOrDefault((x) =>
                x.GetAlpha3Code() == countryName || x.GetAlpha2Code() == countryName, null);

                if (val is not null)
                {
                    return val.GetAlphaNumericPair();
                }
                else return null;
            }
        }
        public KeyValuePair<string, IAlphaCountryCode>? isValidCountry(int alphaNumeric)
        {
            var val = Values.FirstOrDefault((x) => x.GetAlphaNumeric() == alphaNumeric, null);
            if (val is not null)
            {
                return val.GetAlphaNumericPair();
            }
            else return null;
        }

        public bool TryGetValue(string key, [MaybeNullWhen(false)] out IAlphaCountryCode value)
        {
            return ((IReadOnlyDictionary<string, IAlphaCountryCode>)di).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)di).GetEnumerator();
        }

        public ValidateCountryCode(Dictionary<string, IAlphaCountryCode> di)
        {
            this.di = di;
        }
    }
}
