using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.Reflection.Metadata;

using VeryGenericSite.Services.BookingService.ResponseSender;
//think i should run a config for this where the config reaches into the current session as this will be transient
//and returns whatever value the response of the ContactForm handler is.
namespace VeryGenericSite.Services.BookingService.BookingReciever
{
    public interface IContactFormResponseReciever<T> where T : class, IContactForm
    {
        IContactResponseSender GenerateResponose(T FormValues);

    }
}


