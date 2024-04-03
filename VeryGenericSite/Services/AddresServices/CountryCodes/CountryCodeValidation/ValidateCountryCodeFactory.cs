using Microsoft.CodeAnalysis.CSharp.Syntax;

using NuGet.Packaging;

using System.CodeDom;
using System.Drawing.Printing;
using System.IO;

using VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation.Interfaces;
using VeryGenericSite.Services.AddresServices.CountryCodes.Interfaces;

namespace VeryGenericSite.Services.AddresServices.CountryCodes.CountryCodeValidation
{
    //I should be able to do CRTP with this to override implementations of the base type while maintaining interfaces
    //with the ServiceCollection
    public abstract class ValidateCountryCodeFactory<T> : IValidateCountryCodeFactory<T> where T :
        ICountryCodeValidator
    {
        private IValidationCodeFactory _codeFactory { get; }

        protected T _allowedCodes;
        protected T AllowedCodes
        {
            get
            {
                return _allowedCodes;
            }
            init
            {
                if (_allowedCodes == null)
                {
                    _allowedCodes = value;
                }
            }
        }
        protected T GetAllowedAlphaCodes()
        {
            return AllowedCodes;
        }
        public async Task<T> CreateAsync()
        {
            if (_allowedCodes == null)
            {
                _allowedCodes = (T?)await Populate();
            }
            return AllowedCodes;
        }
        //this is hardcoded when it should'be there should be some service deciding how this is done 
        //
        protected virtual async Task<IReadOnlyDictionary<string, IAlphaCountryCode>> Populate()
        {
            //this should be moved out to the config.
            string path = "/CountryCodes/List of country codes by alpha-2, alpha-3 code (ISO 3166).txt";
            string SectionStart = "</tr><tr>";
            string DataSectionStart = "<td>";
            string DataSectionEnd = "</td>";
            int dataSectionCount = -1;
            Dictionary<string, IAlphaCountryCode> Codes = new();
            string[] data = new string[4];
            using (StreamReader reader = new StreamReader(Path.GetFullPath(path)))
            {
                try
                {
                    string? line = string.Empty;
                    while (!((line = await reader.ReadLineAsync()) == null))
                    {
                        if (dataSectionCount == 5)
                        {
                            int result = int.TryParse(data[3], out result) ? result : 00000;
                            Codes.Add(
                            data[0],
                            _codeFactory.Create(
                            data[1].ToCharArray(),
                            data[2].ToCharArray(),
                            result,
                            data[0]));
                        }
                        if (line.Contains(SectionStart))
                        {
                            dataSectionCount = 0;
                            continue;
                        }
                        data[dataSectionCount] = line.Remove(line.IndexOf(DataSectionStart), DataSectionStart.Length)
                                                     .Remove(line.IndexOf(DataSectionEnd), DataSectionEnd.Length);
                        ++dataSectionCount;
                    }
                }
                catch (Exception e)
                {
                    if (e is OutOfMemoryException)
                    {
                        Console.WriteLine(e.ToString(), e.Message);
                    }
                    else if (e is IOException)
                    {
                        Console.WriteLine(e.ToString(), e.Message);
                    }
                    else throw e;
                }
                finally
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            return Codes;
        }
        public ValidateCountryCodeFactory(IValidationCodeFactory codeFactory)
        {
            _codeFactory = codeFactory;
        }
    }
}
