using System;
using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<TItem> OneAtATIme<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }

    public static IEnumerable<TItem> AllPetsWhere<TItem>(Predicate<TItem> condition, IList<TItem> items)
    {
        foreach (var item in items)
        {
            if (condition(item))
                yield return item;
        }
    }
}