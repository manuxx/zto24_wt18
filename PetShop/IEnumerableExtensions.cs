using System.Collections.Generic;
using Training.DomainClasses;

public static class IEnumerableExtensions
{
    public static IEnumerable<TItem> ToProtectedIEnumerable<TItem>(this IEnumerable<TItem> enumerable)
    {
        foreach (var element in enumerable)
        {
            yield return element;
        }
    }
}