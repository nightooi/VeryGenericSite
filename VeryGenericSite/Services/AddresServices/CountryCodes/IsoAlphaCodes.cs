using Microsoft.CodeAnalysis.Elfie.Model.Strings;

using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using System.Reflection.Metadata;
using System.Reflection;

using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces;
using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;
using Microsoft.CodeAnalysis.Operations;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Writers;
using Microsoft.CodeAnalysis;
using VeryGenericSite.Configuration;
using VeryGenericSite.Configuration.Defaults;
using VeryGenericSite.Configuration.Defaults.Validations;
using VeryGenericSite.Configuration.Defaults.Validations.CountryCodeValidations;


namespace VeryGenericSite.Services.AddresServices.CountryCodes
{
    [Serializable()]
    public class IsoAlphaCodes : IAlphaCountryCode
    {

        IDefaultInitializer<IAlphaCountryCode> _defaultInitializer;
        private string _countryName;
        public string Country {
            get
            {
                return _countryName;
            }
            init
            {
                if(this is not null && _countryName is null)
                {
                    _countryName = value;
                }
            }
        }
        private char[] Alpha2 { get; set; }
        private char[] Alpha3 { get; set; }
        private int Alphanumeric { get; set; }
        public string GetAlpha2Code()
        {
            return Alpha2.ToString()!;
        }
        public string GetAlpha3Code()
        {
            return Alpha3.ToString()!;
        }
        public int GetAlphaNumeric()
        {
            return Alphanumeric!;
        }
        KeyValuePair<string, IAlphaCountryCode> IAlphaCountryCode.GetAlphaNumericPair()
        {
            return new KeyValuePair<string, IAlphaCountryCode>(Country, this);
        }
        public IsoAlphaCodes()
        {
        }
        public IsoAlphaCodes(
            KeyValuePair<string, IAlphaCountryCode>? countrycode,
            IDefaultInitializer<IAlphaCountryCode> defualt)
        {
            if (countrycode is not null)
            {
                Alphanumeric = countrycode.Value.Value.GetAlphaNumeric();
                Alpha2 = countrycode.Value.Value.GetAlpha2Code().ToCharArray();
                Alpha3 = countrycode.Value.Value.GetAlpha3Code().ToCharArray();
                Country = countrycode.Value.Key;
            }
            _defaultInitializer = defualt;
        }
    }
    public interface IAlphaCountryCodeDefault : IDefaultInitializer<IAlphaCountryCode>
    {

    }
    public interface IDefaultInitializer<T>
    {
        T DefaultValue { get; }
    }
    public static class DefaultCountryCodeOptions
    {

        public static IServiceCollection AddConfig(this IServiceCollection services, IConfiguration config)
        {

        }
        public static void DefaultAlphaCode(IServiceCollection services)
        {

            services.AddSingleton<IAlphaCountryCodeDefault>(
              x => () =>
              {
                  AlphaCountryCodeDefault def = new();
              }
                );
        }
    }
    public class AlphaCountryCodeDefault : IAlphaCountryCodeDefault
    {
        public IAlphaCountryCode DefaultValue { get; }

        public AlphaCountryCodeDefault(IOptions<IAlphaCountryCode> options)
        {
            DefaultValue = options.Value;
        }
    }
}







