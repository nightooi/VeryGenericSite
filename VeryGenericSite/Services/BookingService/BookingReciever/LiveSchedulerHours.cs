using System.Collections;

namespace VeryGenericSite.Services.BookingService.BookingReciever
{

    //
    //  there is still some issues here. As we start to fill out the bookings i need to switch
    //  too optimize for free time. meaning at some point this will have to dump the contents to 
    //  too disk/database and then only retain those values that are free... 
    //  approach will be polymorphism i think, basically to switch service type.Depending on how filled out
    //  a given month is too lower the amount of work.
    //
    // this has too much functionality, i need to extrude some of it, like... validation shouldn't really be here...
    //  it should be in one of the layers above or have a valdiation dependecy.
    //  this layer should only really deal with the imperative system level code for the implementation.
    //
    // pruning needs to be implemented
    // the more i think about this the more i realize there needs to be 
    // some sort of a dynamic config class..
    //
    public class LiveSchedulerHours : ISchedulerHours
    {
        // I have to run this through a config... No clue how to even do that
        private const int _startSize = 2;
        private readonly byte _day;
        public byte Day
        {
            get
            {
                return _day;
            }
            init
            {
                _day = value;
            }
        }
        private int _extend;
        private int _taken = 0;
        private TimeOnly _startHour;
        private TimeOnly _maxHour;
        private TimeSpan _BasicDuration;

        private TimeOnly[] _hours = new TimeOnly[_startSize];
        private bool _disposed = false;
        public TimeOnly this[int i]
        {
            get
            {
                return _hours[i];
            }
            set
            {
                _hours[i] = value;
            }
        }
        //
        // Can't really just resize here... I mean where am i checking if the booking is withing specified range???
        // this implementation is too closly tied to the booking times... like this treats each booking to be atleast an hour..
        // smaller than an hour..
        //
        private void Resize()
        {
            var phold = new TimeOnly[_hours.Length + _extend];
            Array.Copy(_hours, phold, _hours.Length);
            _hours = phold;
        }
        private int CalcOverShoot(int maxHour, int extend)
        {
            var re = maxHour - _startSize;
            var overshoot = re % extend;
            return overshoot;
        }
        public IEnumerator GetEnumerator()
        {
            return _hours.GetEnumerator();
        }
        // 
        // How large of an operation should this even be?? 
        // to throw out a suggestion that would be prefferable we need infomation about the 
        // customer, age, merital status, children, Income, employment status, character etc..
        // anyhow this has to be decided by some other layer that interfaces with the cookie registration.
        // If this function is too have some input paramter, it should be some abstraction of what times
        // should be selected for, simply throwing out a bunch of values here is dumb 'cus im just postponing
        // the selection work to the Layer above and worst of all creating unnessecary copies.
        // lets overload it later.
        // I somehow also will need to pair a singleton with a transient... 
        // 
        // once again this treats booking to be atleast one hour wich is fine for this use-case, but it doesnt
        // have any modifiability..
        // Which is fine cus i can just create a reimplementation it later and just throw in using DI, cus interfaces.
        // 
        // Okey but if we have Available function here, this will in other words have a dependency in validation
        // with validation having a dependency in system configuration and this should all be solved...
        // 
        // It's kinda bad but not could be worse..
        // 
        //  this is assuming 2 hours for each... once again we could book less but who cares rn.
        // 
        public IEnumerable<TimeOnly> Available()
        {
            TimeSpan duration, res;
            int bookingsAvailable;
            for (int i = 0; i < _taken; i++)
            {
                res = i < _taken &&
                    (duration = _hours[i] - _hours[i + 1]) >= _BasicDuration
                    ? duration : TimeSpan.Zero;
                if (!(res == TimeSpan.Zero))
                {
                    bookingsAvailable = (int)res.Divide(_BasicDuration);
                    for (int k = bookingsAvailable; k > 0; k--)
                    {
                        yield return new TimeOnly(_hours[i].Hour + _BasicDuration.Hours,
                            _hours[i].Minute + _BasicDuration.Minutes);
                    }
                }
            }
        }
        //
        // 
        // once again i need to make sure that this is allowable...
        // and this does indeed have a partial/loose dependecy within
        // both client context and booker context... as well as Validation
        // 
        /// <summary>
        ///     Validation is done Before anything else dumb f.
        ///     In this case though validation Has a dependency in searching..
        ///     
        ///     This will be reimplemented, as i get a normal data validator for now 
        ///     just facotry initialize this with 
        /// </summary>
        /// <param name="hour"></param>
        /// <returns></returns>
        public bool BookTime(TimeOnly hour)
        {
            if (_startHour > hour && hour < _maxHour)
            {
                return false;
            }
            int res = Array.BinarySearch(_hours, hour);
            if (!(res > 0))
            {
                if (_taken < _hours.Length)
                {
                    _hours[_taken] = hour;
                }
                else
                {
                    Resize();
                    _hours[_taken] = hour;
                }
                ++_taken;
                // this needs to be spliced off into a thread
                Array.Sort(_hours);
                return true;
            }
            return false;
        }
        IEnumerator<TimeOnly> IEnumerable<TimeOnly>.GetEnumerator()
        {
            return (IEnumerator<TimeOnly>)GetEnumerator();
        }
        public IEnumerable<TimeOnly> Available(TimeSpan Span)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     I'll have to redefine every contstructor... Or just go with dependency injection.
        /// </summary>
        public LiveSchedulerHours(TimeOnly starttime, TimeOnly endtime,
            TimeSpan basicduration, int extensionsize, byte day)
        {
            _startHour = starttime;
            _maxHour = endtime;
            _BasicDuration = basicduration;
            _extend = extensionsize;
            _day = day;
        }
    }
}
