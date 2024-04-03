using Microsoft.CodeAnalysis.CSharp.Syntax;

using System.Collections;

namespace VeryGenericSite.Services.BookingService.BookingReciever
{
    public abstract class LiveSchedulerBase
    {
        protected bool _allowDoubleBookings;
        protected bool _allowFullTargetBookings;
        protected int _expand;
        protected int _taken = 0;
        protected virtual void Resize<T>(T[] _target, IComparer<T> _compareTarget)
        {
            var pHold = new T[_target.Length + _expand];
            Array.Copy(_target, pHold, _target.Length);
            _target = pHold;
            Array.Sort(pHold, _compareTarget);
        }

        public LiveSchedulerBase(
            bool allowDoubleBookings,
            bool allowFullTargetBookings,
            int expand)
        {
            _allowDoubleBookings = allowDoubleBookings;
            _allowFullTargetBookings = allowFullTargetBookings;
            _expand = expand;
        }
    }
}