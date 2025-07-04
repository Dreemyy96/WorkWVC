using System.Diagnostics.CodeAnalysis;

namespace WorkingWithVisualStudio.Tests
{
    internal class Comparer
    {
        public static Comparer<U> Get<U>(Func<U, U, bool> func)
        {
            return new Comparer<U>(func);
        }
    }
    internal class Comparer<T>: Comparer, IEqualityComparer<T>
    {
        private Func<T, T, bool> comparisionFunction;

        public Comparer(Func<T, T, bool> comparisionFunction)
        {
            this.comparisionFunction = comparisionFunction;
        }

        public bool Equals(T? x, T? y)
        {
            return comparisionFunction(x, y);
        }

        public int GetHashCode([DisallowNull] T obj)
        {
            return obj.GetHashCode();
        }
    }
}
