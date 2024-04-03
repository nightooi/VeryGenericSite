using VeryGenericSite.Models;

using System.Reflection.Metadata.Ecma335;

using VeryGenericSite.Services.BookingService.ResponseSender;

namespace VeryGenericSite.Services.BookingService.BookingReciever
{
    //this will have a dependecy in validation, i'll want to run the validation from here or previously.
    //either way i think i need a factory for creating responses...

    public class ResponseReciever<T> : IContactFormResponseReciever<T> where T : class, IContactForm
    {
        public IContactResponseSender GenerateResponose(T FormValues)
        {
            var v = FormValues.GetFields();
            IContactResponseSender sender;
            return sender;

        }

        //For now lets assume that the data is validated and functioning.
        //Later functions for confirmation of the data will be added.
        private readonly bool DataParser(ref string? key, ref string? val)
        {
        }
    }
}
