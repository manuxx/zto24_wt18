using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtentions
{
    public static IEnumerable<T> ToEnumerable<T>(IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}