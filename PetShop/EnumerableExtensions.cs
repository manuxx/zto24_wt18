using System;
using System.Collections.Generic;

namespace Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<Item> AllItemsWhere<Item>(this IEnumerable<Item> items, Predicate<Item> condition)
    {
        foreach (var item in items)   
        {
            if (condition(item))
            {
                yield return item;
            }
        }
    }
}