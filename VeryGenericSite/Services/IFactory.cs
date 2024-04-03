using Humanizer;

using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.CodeAnalysis.CSharp.Syntax;

using VeryGenericSite.Services.BookingService.BookingReciever;

namespace VeryGenericSite.Services
{
    public interface IFactoryProvider<T> where T: new()
    {
        IEnumerable<T> Factories { get; }
        Func<T>? Factory { get; }
        Func<bool, T>? SelectFactory { get; }
        T CreateFactory();
    }
    public class FactoryProvider<T> : IFactoryProvider<T> where T : new()
    {
        public IEnumerable<T> Factories { get; }

        public Func<T>? Factory { get; }

        public Func<bool, T>? SelectFactory { get; }

        public T CreateFactory()
        {
            var a = Factories.Where(x => x.GetType() == typeof(T));
            return a.FirstOrDefault()!;
        }
        public FactoryProvider(IEnumerable<T> factories)
        {
            if(Factories is not null)
            {
                Factories.ToList().AddRange(factories);
            }
            else
            {
                Factories = factories;
            }
        }
        public FactoryProvider(T factories)
        {
            if(Factories is not null)
            {
                Factories.Append(factories);
            }
            else
            {
                Factories = new List<T>();
                Factories.Append(factories);
            }
        }
    }
}
