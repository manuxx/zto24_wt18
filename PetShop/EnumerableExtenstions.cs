using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtenstions
{
    public static IEnumerable<TItem> OneAtATime<TItem>(this IList<TItem> items)
    {
        foreach (var it in items)
        {
            yield return it;
        }
    }
}