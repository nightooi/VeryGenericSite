namespace VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces
{
    public interface IAlphaCountryCode
    {
        string GetAlpha2Code();
        string GetAlpha3Code();
        int GetAlphaNumeric();
        KeyValuePair<string, IAlphaCountryCode> GetAlphaNumericPair();
    }
}