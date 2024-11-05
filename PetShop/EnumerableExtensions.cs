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

    public static IEnumerable<TItem> AllWhere<TItem>(this IEnumerable<TItem> enumerable, Predicate<TItem> condition)
    {
        return enumerable.AllWhereCriteria(new AnonymousCriteria<TItem>(condition));
    }

    public static IEnumerable<TItem> AllWhereCriteria<TItem>(this IEnumerable<TItem> enumerable, ICriteria<TItem> criteria)
    {
        foreach (TItem p in enumerable)
        {
            if (criteria.IsSatisfiedBy(p)) yield return p;
        }
    }
}

public class AnonymousCriteria<TItem>: ICriteria<TItem>
{
    private readonly Predicate<TItem> _predicate;
    public AnonymousCriteria(Predicate<TItem> acceptance)
    {
            _predicate = acceptance;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _predicate(item);
    }
}

public interface ICriteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}