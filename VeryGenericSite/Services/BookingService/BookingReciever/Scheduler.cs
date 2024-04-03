
using System.Collections;

namespace VeryGenericSite.Services.BookingService.BookingReciever
{
    //Need to create abstraction for Serialization/Databaseconnection with this class having a dependency for it.
    // This is also gonna have dependecies in the service reaching out into the googleAPI to calculate travel time...
    //for now lets just do something that saves to Disk..

    /// <summary>
    /// This will have to be a Singleton, there was something about having transients with dependecies in singletons... 
    ///     might cause trouble.
    ///     this needs a approach swap, instead of looking for booked dates there should be a list of dates available to book
    ///     makes this whole process much easier and faster. Though it's not completely accurate as we allow for random bookings..
    /// 
    /// Theres another dependency of which i am unsure and that's the dumping of data and also the keeping tab of who
    ///     booked it and when....
    /// Also Serialization which wll be called from the dump cache...
    /// 
    ///  TODO: extrude abstract class with protected stuff it should include like the implementation for the 
    ///  resize method. And protected members which are common and nessecary for the implmentation, its signuature 
    ///  should be abstract Scheduler<T> where T is the Backing Array type..
    /// </summary>
    public class LiveScheduler : IScheduler
    {

        private List<int>[] _MonthesByDay;

        private enum CacheLoad { Partial, Full }
        private const string path = "../Scheduler/Scheduler.txt";
        private const int ScheduleCacheSize = 2048;
        // the cache will prefer to fill out from the back, meaning it will prioritize to fill out all
        // holes in the back. so if we work on a year->month->day->hour->minute basis the worst case scenario
        // should be only about 24.. if we scale down the time to buisness hours its gonna be 8.
        private DateTime[] DateCache = new DateTime[ScheduleCacheSize / 12];
        //linked list->year,  List->Month,  day->int[1,], Hour->int[,2] 
        public ref readonly DateTime[] PossibleDates()
        {

            return ref DateCache;
        }
        public bool TimeAvailable(DateTime date, ICustomer customer)
        {
            bool flag = false;
            if (date < DateTime.Now) return false;
            int yearOffset = YearOffset(date.Year);

        }
        //populate with available times. Ordered!
        private int OnStartUpPopulate()
        {
        }
        //
        private Task<int> LoadUpCache(string path, CacheLoad dump)
        {
        }
        private Task FlushCache()
        {
        }

        private DateTime[] AddDateTimes();
        private int YearOffset(int year)
        {
            int Currentyear = DateTime.Now.Year;
            if (Currentyear > year)
            {
                return Currentyear - year;
            }
            return year - Currentyear;
        }
        private void Restructure()
        {

        }
    }

    public class LiveShedulerYear<T ,U> : LiveSchedulerMonth<LiveShedulerYear<T, U>, LiveSchedulerHours>
    {

    }

    /// <summary>
    ///     Add: By week, search option.
    ///     
    ///     Extend, add and book needs to be implmented
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public class LiveSchedulerMonth<T, U> : LiveSchedulerBase, ISchedulerMonth<T, U>
                                                                  where T : class, ISchedulerDays<U>, IComparer
                                                                  where U : class, ISchedulerHours
    {
        protected ISchedulerDayFactory _dayFactory;
        T[] _months;

        protected readonly byte _month;
        public byte month
        {
            get { return _month; }
            init { _month = value; }
        }

        //implement the variation for double bookings....
        public LiveSchedulerMonth(
            ISchedulerDayFactory dayFactory, IComparer compareByMonth,
            T[] months, byte month, int expand,
            bool allowMonthLongBookings, bool allowDoubleBookings)
        {
        }

        public async Task<bool> BookTime(DateTime bookDay,
            CancellationToken cancellation)
        {
            int res = Array.BinarySearch(
                _months, bookDay.Month);
            if (res > 0)
            {
                return await _months[res].BookTime(
                    bookDay.Day, new TimeOnly(
                        bookDay.Hour, bookDay.Minute),
                    cancellation);
            }
            if (_taken < _months.Length)
            {
                _months[res] = (T)_dayFactory.CreateDayScheduler(
                    SchedulerType.BookedConfig, (byte)bookDay.Month);
                ++_taken;
                return true;
            }
            Resize();
            _months[res] = (T)_dayFactory.CreateDayScheduler(
                SchedulerType.BookedConfig, (byte)bookDay.Month);
            ++_taken;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _months.AsEnumerable().GetEnumerator();
        }

        public T? GetMonth(int month)
        {
            int res = Array.BinarySearch(
                _months, month);
            if (res > 0)
            {
                return _months[res];
            }
            return null;
        }
        //Available throughout the entire year, use overload with specified month for only 1 month.
        public async Task<IEnumerable<Task<IEnumerable<U>>>> Available(
        CancellationToken cancellation)
        {
            return await Task.Run(
                new Func<IEnumerable<Task<IEnumerable<U>>>>(() =>
                {
                    return AvailableHelper(cancellation);
                }));
        }

        private IEnumerable<Task<IEnumerable<U>>> AvailableHelper(CancellationToken cancellation)
        {
            for (int i = 0; i < _months.Length; i++)
            {
                yield return Task.Run(new Func<Task<IEnumerable<U>>>(async () =>
                {
                    return await _months[i].Available(cancellation);
                }));
            }
        }
        private IEnumerable<Task<IEnumerable<U>>> AvailableHelper(CancellationToken cancellation, Func<U, int, bool> func)
        {
            for (int i = 0; i < _months.Length; i++)
            {
                yield return Task.Run(new Func<Task<IEnumerable<U>>>(async () =>
                {
                    return await _months[i].Available(func, cancellation);
                }));
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public async Task<IEnumerable<Task<IEnumerable<U>>>> Avaliable(Func<U, int, bool> predicate,
        CancellationToken cancellation)
        {
            return await Task.Run(
                new Func<IEnumerable<Task<IEnumerable<U>>>>(() =>
                {
                    return AvailableHelper(cancellation, predicate);
                }));
        }
    }
    /// <summary>
    ///     Validation interface will need to be extruded out of this!!
    ///     
    ///     resize/ prune not implemented, it should be a cascading interface function
    ///     to remove old dates..
    ///     
    ///     ISchedulerDays expets the HourDependecy to be populated, user has no clue
    ///     this has to be implemented using the factory pattern, meaning i have 
    ///     to initialize it using factory pattern and DI, no clue how to.
    ///     
    ///     Once again Resize interface needs to be extruded and made a dependency of this class.
    ///     
    /// </summary>
    public class LiveSchedulerDays<T> : ISchedulerDays<T> where T : class, ISchedulerHours
    {

        private IComparer _compareByDay;

        private ISchedulerHoursFactory _hoursFactory;
        private byte _month;
        //will have to come from config.
        private const int _startSize = 2;
        //will have to come from config.
        private readonly int _expand;
        private int _taken = 0;
        private int Expand
        {
            get
            {
                return _expand;
            }
            init
            {
                _expand = value;
            }
        }
        private T[] SchedulerHours;
        public LiveSchedulerDays(byte month, byte[] forbiddenDates, IEnumerable<T> hours,
            IComparer hourComparer, ISchedulerHoursFactory factory)
        {
            SchedulerHours = hours.ToArray();
            _compareByDay = hourComparer;
            _hoursFactory = factory;
            _nonBookableDates = forbiddenDates;
            _month = month;
        }
        private readonly byte[] _nonBookableDates;
        private int _extendSize;
        private bool _doubleBookings;

        public IEnumerator<T> GetEnumerator()
        {
            return SchedulerHours.AsEnumerable().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        //Available for the entire month;
        public async Task<IEnumerable<T>> Available(CancellationToken cancel)
        {
            return await new Task<IEnumerable<T>>(new Func<IEnumerable<T>>(() =>
            {
                return SchedulerHours.Where(x => x.Available().Count() > 0);
            }), cancel, TaskCreationOptions.PreferFairness);
        }

        public async Task<IEnumerable<T>> Available(Func<T, int, bool> predicate, CancellationToken cancel)
        {
            return await new Task<IEnumerable<T>>(new Func<IEnumerable<T>>(() =>
            {
                return SchedulerHours.Where(predicate);
            }), cancel, TaskCreationOptions.PreferFairness);
        }

        public async Task<bool> BookTime(int day, TimeOnly start, CancellationToken cancel)
        {
            return await new Task<bool>(new Func<bool>(() =>
            {

                byte d = (byte)day;
                int res;
                res = Array.BinarySearch(SchedulerHours, day, _compareByDay);
                if (res > 0)
                {
                    return SchedulerHours[res].BookTime(start);
                }
                if (_taken < SchedulerHours.Length)
                {
                    SchedulerHours[_taken] = (T)_hoursFactory.CreateHourScheduler(SchedulerType.BookedConfig, d);
                    ++_taken;
                    return true;
                }
                Resize();
                SchedulerHours[_taken] = (T)_hoursFactory.CreateHourScheduler(SchedulerType.BookedConfig, d);
                Array.Sort(SchedulerHours, _compareByDay);
                ++_taken;
                return true;
            }), cancel, TaskCreationOptions.PreferFairness);
        }
        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="day"></param>
        /// <param name="duration"></param>
        /// <param name="start"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> BookTime(int day, TimeSpan duration, TimeOnly start, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="day"></param>
        /// <param name="duration"></param>
        /// <param name="end"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> BookTimeWithEnd(int day, TimeSpan duration, TimeOnly end, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="duration"></param>
        /// <param name="start"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<int> BookAnyDay(TimeSpan duration, TimeOnly start, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// NOT IMPLMENTED
        /// </summary>
        /// <param name="day"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<TimeOnly> BookAnyDuringDay(int day, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// NOT IMPLEMENTED
        /// </summary>
        /// <param name="day"></param>
        /// <param name="time"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<TimeOnly> BookAnyDuringDay(int day, TimeSpan time, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }
        public T this[int i]
        {
            get
            {
                return SchedulerHours[i];
            }
            set
            {
                SchedulerHours[i] = value;
            }
        }
        public T? GetDay(int day)
        {
            int res = Array.BinarySearch(SchedulerHours, day, _compareByDay);
            if (res > 0)
            {
                return this[res];
            }
            return null;
        }
        private void Resize()
        {
            var pHold = new T[SchedulerHours.Length + _expand];
            Array.Copy(SchedulerHours, pHold, SchedulerHours.Length);
            SchedulerHours = pHold;
        }
    }

    public interface ISchedulerMonth<T, U> : IEnumerable<T> where T : ISchedulerDays<U>
                                           where U : class, ISchedulerHours
    {
        //I may have to introduce webworkers and a websocket to get the response out fast enough
        T? GetMonth(int month);
        Task<bool> BookTime(DateTime bookDay, CancellationToken cancellation);
        Task<IEnumerable<Task<IEnumerable<U>>>> Available(CancellationToken cancellation);
        Task<IEnumerable<Task<IEnumerable<U>>>> Avaliable(Func<U, int, bool> predicate,
        CancellationToken cancellation);
    }
    public interface ISchedulerDays<T> : IEnumerable<T> where T : class, ISchedulerHours
    {
        Task<bool> BookTime(int day, TimeOnly start, CancellationToken cancel);
        Task<bool> BookTime(int day, TimeSpan duration, TimeOnly start, CancellationToken cancel);
        Task<bool> BookTimeWithEnd(int day, TimeSpan duration, TimeOnly end, CancellationToken cancel);
        Task<int> BookAnyDay(TimeSpan duration, TimeOnly start, CancellationToken cancel);
        Task<TimeOnly> BookAnyDuringDay(int day, CancellationToken cancel);
        Task<TimeOnly> BookAnyDuringDay(int day, TimeSpan time, CancellationToken cancel);
        T? GetDay(int day);
        Task<IEnumerable<T>> Available(CancellationToken cancel);
        Task<IEnumerable<T>> Available(Func<T, int, bool> predicate, CancellationToken cancel);
    }
    //Todo: Redefine the time interface entirely 
    public interface IAsyncBooker<T>
    {
        Task<bool> Booktime(T localLookupValue, CancellationToken cancel);
        Task<bool> BookTime(T localLookupValue, T LocalStart, CancellationToken token, TimeSpan? duration);
        Task<bool> BookWithEndTime(T localLookupValue, TimeSpan duration, T end, CancellationToken cancel);
        Task<TimeOnly> BookAnyDay(TimeSpan duration, CancellationToken cancel);
        Task<TimeOnly> BookAnyDuringDay(T localLookupValue, CancellationToken cancel);
    }
    public interface IBooker<T>
    {
        bool BookTime(T localLookupValue, CancellationToken cancel);
        bool BookTime(T localLookupValue, T localStart, )
    }
    

    //
    // Schedule maker should have some sort of dependecy which runs the logic for a given scheduling event
    // against the current customer context... 
    // all of this is just solved with a unit displaying available times....
    // This would also create a soft-dependency within data-validation for bookings.
    //
    public interface IScheduleMaker<T> where T : IEnumerable<T>
    {
        T GetAllowedSchedule(SchedulingPriority schedulingPriority, SchedulingType schedulingType);
    }
    public enum SchedulingPriority { High, Medium, Low }
    public enum SchedulingType { Office, Evening, Night, Morning, Afternoon }

    public interface IResize
    {
        //make resize a a private variable of the Hour class
    }

    public interface ISchedulerHoursFactory
    {
        ISchedulerHours CreateHourScheduler(SchedulerType type, byte day);
    }

    public interface ISchedulerDayFactory : IFactory<ISchedulerDays<ISchedulerHours>>
    {
        ISchedulerDays<ISchedulerHours> CreateDayScheduler(SchedulerType type, byte month);
    }
    public enum SchedulerType { BookedConfig, FreeConfig }

}
