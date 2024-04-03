using VeryGenericSite.Services.AddresServices.CountryCodes;
using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;
using System.Text.Json.Serialization;

namespace VeryGenericSite.Configuration.Defaults.Validations.CountryCodeValidations
{
   [JsonSerializable(type: typeof(string),
        GenerationMode = 
        JsonSourceGenerationMode.Default|
        JsonSourceGenerationMode.Metadata,
        TypeInfoPropertyName ="Configurations.Defaults.ValidationDefaults.IsoAlphaCodeDefaults" )]
    public partial class IsoAlphaCodeDefaults : IAlphaCountryCodeDefault
    {
        public string Alpha3 { get; set; }
        public string Alpha2 { get; set; }
        public int Alphanumeric { get; set; }

        public IAlphaCountryCode DefaultValue => this.DefaultValue = 
    }
}
