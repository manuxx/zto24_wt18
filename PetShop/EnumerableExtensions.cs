using System.Collections.Generic;

public static class EnumerableExtensions
{
    public static IEnumerable<T> OneAtTime<T>(this IEnumerable<T> items)
    {
        foreach (var item in items)
        {
            yield return item;
        }
    }
}