using System.Collections.Generic;

namespace PetShop;

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