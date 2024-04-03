using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace VeryGenericSite.Services.BookingService.BookingReciever
{
    public interface IScheduler
    {
        bool TimeAvailable(DateTime date, ICustomer customer);
        ref readonly DateTime[] PossibleDates();
    }
    public interface ICustomer
    {
        IPersonalInfo GetPersonalInfo();
        string GetAddress();
        string getPhoneNumber();
        bool IsPersonalInfoVerified();
    }
    public interface IContactInfo<T> : ICustomerPhoneInfo, ICustomerNameInfo

    {
        //should be an IFormattable with dependecies in IFormatProvider
        string GetPhoneNumber();
        string GetEmail();
        IFormattable GetContactInfo();
        bool IsPhoneConfirmed();
        bool IsEmailConfirmed();
        bool IsAddressConfirmed();
    }

    public interface ICustomerNameInfo<T> where T : ICustomFormatter
    {
        string GetName();
        IFormattable FormattableName(T formatProvider);


    }
}


