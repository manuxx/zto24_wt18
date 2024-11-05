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

    public static IEnumerable<TItem> MYMETHOD<TItem>(this IList<TItem> pets, Func<TItem, bool> parametr)
    {
        foreach (var pet in pets)
        {
            if (parametr(pet))
                yield return pet;
        }
    }
}