namespace VeryGenericSite.Services.BookingService.BookingReciever
{
    public interface IPersonalInfo : IAddress, IContactInfo
    {
        string GetAddress();

    }
}


