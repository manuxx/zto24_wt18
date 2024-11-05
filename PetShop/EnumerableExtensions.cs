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

    public static IEnumerable<TItem> Filtered<TItem>(this IEnumerable<TItem> items, Predicate<TItem> filter)
    {
        foreach (var item in items)
        {
            if (filter.Invoke(item)) {
                yield return item;
            }
        }
    }


    public static IEnumerable<Pet> AllPetsWhere(IEnumerable<Pet> pets, Predicate<Pet> predicate)
    {
        return EnumerableExtensions.Filtered(pets, predicate);
    }
}