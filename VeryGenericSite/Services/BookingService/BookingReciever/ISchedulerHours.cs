using System.Collections;

namespace VeryGenericSite.Services.BookingService.BookingReciever
{
    public interface ISchedulerHours : IEnumerable<TimeOnly>
    {
        bool BookTime(TimeOnly hour);
        IEnumerable<TimeOnly> Available();
        IEnumerable<TimeOnly> Available(TimeSpan Span);
    }
}

