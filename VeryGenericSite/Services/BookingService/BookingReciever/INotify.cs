//think i should run a config for this where the config reaches into the current session as this will be transient
//and returns whatever value the response of the ContactForm handler is.
namespace VeryGenericSite.Services.BookingService.BookingReciever
{
    //Maybe just turn this into a attribute?? 
    public interface INotify : IResponseCodeMangler, INotifier
    {
        int NotifyClient(string message, PreferredNotification preferred);
    }
}


