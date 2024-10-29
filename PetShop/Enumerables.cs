using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class Enumerables
    {
        public static IEnumerable<Titem> OneAtATime<Titem>(this IList<Titem> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }
    }
}