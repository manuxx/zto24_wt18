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

    public static IEnumerable<Pet> Condition(this IList<Pet> petsInTheStore, Func<Pet, bool> b)
    {
        foreach (var pet in petsInTheStore)
        {
            if (b(pet))
                yield return pet;
        }
    }
}