using System.Linq;

namespace System.Collections.Generic
{
    public static class EnumerableExtension
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
            => source == null || !source.Any();
    }
}
