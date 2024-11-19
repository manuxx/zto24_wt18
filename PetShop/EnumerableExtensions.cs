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

public class AnonymousCriteria<TItem> : Criteria<TItem>
{
    private readonly Predicate<TItem> _condition;

    public AnonymousCriteria(Predicate<TItem> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _condition(item);
    }
}

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}

public class Conjunction<T> : Criteria<T>
{

    private Criteria<T> _criteria1;
    private Criteria<T> _criteria2;

    public Conjunction(Criteria<T> criteria1, Criteria<T> criteria2)
    {
        this._criteria1 = criteria1;
        this._criteria2 = criteria2;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
    }
}

public class Alternative<T> : Criteria<T>
{

    private Criteria<T> _criteria1;
    private Criteria<T> _criteria2;

    public Alternative(Criteria<T> criteria1, Criteria<T> criteria2)
    {
        this._criteria1 = criteria1;
        this._criteria2 = criteria2;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
    }
}

public class Negation<T> : Criteria<T>
{
    private Criteria<T> _criteria;

    public Negation(Criteria<T> criteria)
    {
        this._criteria = criteria;
    }

    public bool IsSatisfiedBy(T item)
    {
        return !this._criteria.IsSatisfiedBy(item);
    }
}