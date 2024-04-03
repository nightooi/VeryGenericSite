namespace VeryGenericSite.Services.BookingService.ResponseSender
{

    /// <summary>
    ///     Need to insert validification of input, including user info... 
    ///     BankID?
    /// </summary>
    public interface IContactFormResponse
    {
        InvalidInput[]? ValidInput();
        DateTime SuggestedVisit();
        DateTime[] PossibleRebook();

    }
}