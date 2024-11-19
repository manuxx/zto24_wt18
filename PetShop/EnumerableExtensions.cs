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

    public static IEnumerable<TItem> AllItemsThat<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        return items.AllItemsThat(new AnonymousCriteria<TItem>(condition));
    }
    public static IEnumerable<TItem> AllItemsThat<TItem>(this IEnumerable<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    public AnonymousCriteria(Predicate<T> condition)
    {
        throw new NotImplementedException();
    }

    public bool IsSatisfiedBy(T item)
    {
        throw new NotImplementedException();
    }
}

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}