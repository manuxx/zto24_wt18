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

    public static IEnumerable<T> AllItemsWhere<T>(this IList<T> itemsList, Predicate<T> condition)
    {
        foreach (var item in itemsList)
        {
            if (condition(item))
                yield return item;
        }
    }
}