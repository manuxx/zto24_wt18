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

    public static IEnumerable<TItem> AllPetsWhere<TItem>(this IList<TItem> pets, Predicate<TItem> condition)
    {
        return pets.AllPetsWhere(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> AllPetsWhere<TItem>(this IList<TItem> pets, Criteria<TItem> criteria)
    {
        foreach (var pet in pets)
        {
            if (criteria.IsSatisfiedBy(pet))
                yield return pet;
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    public AnonymousCriteria(Predicate<T> condition)
    {
        throw new NotImplementedException();
    }

    public bool IsSatisfiedBy(T pet)
    {
        throw new NotImplementedException();
    }
}

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem pet);
}