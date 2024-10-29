using System.Collections.Generic;

namespace Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<TItem> ToIterator<TItem>(IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}