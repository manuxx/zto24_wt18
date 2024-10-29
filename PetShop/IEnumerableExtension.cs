using System.Collections.Generic;
using Training.DomainClasses;

public static class IEnumerableExtension
{
    public static IEnumerable<TItem> ToIEnumerable<TItem>(this IEnumerable<TItem> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}