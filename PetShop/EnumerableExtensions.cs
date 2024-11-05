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

    public static IEnumerable<TItem> WherePredicate<TItem>(this IEnumerable<TItem> enumerable, Predicate<TItem> acceptance)
    {
        foreach (TItem p in enumerable)
        {
            if (acceptance(p)) yield return p;
        }
    }
}