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

    public static IEnumerable<TItem> AllItemsThat<TItem>(this IList<TItem> items, Predicate<TItem> condition)
    {
        return AllItemsThat(items, new AnonymousCriteria<TItem>(condition));
    }
    
    public static IEnumerable<TItem> AllItemsThat<TItem>(this IList<TItem> items, Criteria<TItem> criteria)
    {
        foreach (var item in items)
        {
            if(criteria.IsSatisfiedBy(item))
                yield return item;
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    private readonly Predicate<T> condition;

    public AnonymousCriteria(Predicate<T> condition)
    {
        this.condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return condition(item);
    }
}

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}