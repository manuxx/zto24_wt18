using System.Collections.Generic;

namespace Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<Pet> ToIterator(IEnumerable<Pet> pets)
    {
        foreach (var pet in pets)
        {
            yield return pet;
        }
    }
}