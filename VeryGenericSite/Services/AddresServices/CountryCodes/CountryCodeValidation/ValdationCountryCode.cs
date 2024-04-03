using Microsoft.AspNetCore.Localization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation
{
    sealed internal class ValidationCountryCode : IAlphaCountryCode
    {
        public string Country { get; init; }
        public char[] Alpha2 { get; init; }
        public char[] Alpha3 { get; init; }
        public int Alphanumeric { get; init; }

        public string GetAlpha2Code()
        {
            return Alpha2.ToString()!;
        }

        public string GetAlpha3Code()
        {
            return Alpha3!.ToString()!;
        }

        public int GetAlphaNumeric()
        {
            return Alphanumeric;
        }

        public KeyValuePair<string, IAlphaCountryCode> GetAlphaNumericPair()
        {
            return new KeyValuePair<string, IAlphaCountryCode>(Country, this);
        }
    }
}
