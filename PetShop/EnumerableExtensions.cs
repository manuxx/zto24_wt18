using System.Collections.Generic;
using Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<Pet> OneAtATime(IEnumerable<Pet> pets)
    {
        foreach (var pet in pets)
        {
            yield return pet;
        }
    }
}