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

    public static IEnumerable<TItem> AllPetsWhere<TItem>(this IList<TItem> pets, Predicate<TItem> condition)
    {
        foreach (var pet in pets)
        {
            if (condition(pet))
                yield return pet;
        }
    }
}