using System;
using System.Collections.Generic;

namespace Training.DomainClasses;

public static class EnumerableExtensions
{
    public static IEnumerable<Item> AllItemsWhere<Item>(this IEnumerable<Item> items, Predicate<Item> condition)
    {
        return items.AllItemsWhere(new AnonymousCriteria<Item>(condition));
    }

    public static IEnumerable<Item> AllItemsWhere<Item>(this IEnumerable<Item> items, Criteria<Item> criteria)
    {
        foreach (var item in items)
        {
            if (criteria.IsSatisfiedBy(item))
            {
                yield return item;
            }
        }
    }
}

public class AnonymousCriteria<T>: Criteria<T>
{

    private Predicate<T> _condition;

    public AnonymousCriteria(Predicate<T> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(T item)
    {
        return _condition(item);
    }
}

public interface Criteria<T>
{
    bool IsSatisfiedBy(T item);
}