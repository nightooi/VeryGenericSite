using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace VeryGenericSite.Services.FormReciever
{
    //Add ServerSide data validation here to normalise for the model
    //Ideally these would be templated out and created automatically by plugging into the razor templating engine...
    public interface IFormReciever<T>
    {
        IDictionary<T, string> GetFormValues();
    }

    public enum Fields { fName, lName, StreetAddress, ZipCode, City, State, Country, PhoneNumber, }

}
