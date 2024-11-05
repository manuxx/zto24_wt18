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

    public static IEnumerable<TItem> AllItemsWhere<TItem>(this IEnumerable<TItem> items, Predicate<TItem> condition)
    {
        return items.AllItemsWhere(new Criteria<TItem>(condition));
    }

    public static IEnumerable<TItem> AllItemsWhere<TItem>(this IEnumerable<TItem> items, ICriteria<TItem> condition)
    {
        foreach (var item in items)
        {
            if (condition.IsSatisfiedBy(item))
                yield return item;
        }
    }
}

public class Criteria<T>: ICriteria<T>
{
    private Predicate<T> _condition;
    public Criteria(Predicate<T> condition)
    {
        this._condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface ICriteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}