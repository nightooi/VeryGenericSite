//think i should run a config for this where the config reaches into the current session as this will be transient
//and returns whatever value the response of the ContactForm handler is.
namespace VeryGenericSite.Services.BookingService.BookingReciever
{
    public interface IMailClient
    {
    }
    public interface IPhoneClient
    {
    }
    public interface IClientMailInfo
    {
    }
    public interface IMessageSender<T> where T : IContactInfo
    {
        int SendMessage(string Message, IContactInfo contactinfo);
    }
}


