namespace VeryGenericSite.Services.BookingService.ResponseSender
{
    public interface IContactResponseSender
    {
        IContactFormResponse SendResponse(IContactFormResponse toBePopulated);
    }
}