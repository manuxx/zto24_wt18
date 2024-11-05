using System;
using System.Collections.Generic;
using System.Diagnostics;
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

    public static IEnumerable<T> AllItemsWhere<T>(this IList<T> itemsList, Predicate<T> condition)
    {
        return itemsList.AllItemsWhere(new AnonymousCriteria<T>(condition));
    }

    public static IEnumerable<T> AllItemsWhere<T>(this IList<T> itemsList, Criteria<T> criteria
    )
    {
        foreach (var item in itemsList)
        {
            if (criteria.isSatisfiedBy(item))
                yield return item;
        }
    }
}

public class AnonymousCriteria<T> : Criteria<T>
{
    private Predicate<T> _condition;
    public AnonymousCriteria(Predicate<T> condition)
    {
        this._condition = condition;
    }

    public bool isSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface Criteria<T>
{
    bool isSatisfiedBy(T item);
}