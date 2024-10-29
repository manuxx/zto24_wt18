using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumerableExtension
    {
        public static IEnumerable<T> OneAtATime<T>(this IEnumerable<T> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}