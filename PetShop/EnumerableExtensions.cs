using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

public class Negation<TItem> : Criteria<TItem>
{
    private Criteria<TItem> _criteria;
    public Negation(Criteria<TItem> criteria)
    {
        _criteria = criteria;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return !_criteria.IsSatisfiedBy(item);
    }
}

public interface Criteria<TItem>
{
    bool IsSatisfiedBy(TItem item);
}

public class Conjunction<TItem> : Criteria<TItem>
{

    private Criteria<TItem> _criteria1;
    private Criteria<TItem> _criteria2;


    public Conjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        _criteria1 = criteria1;
        _criteria2 = criteria2;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _criteria2.IsSatisfiedBy(item) && _criteria1.IsSatisfiedBy(item);
    }
}

public class Alternative<TItem> : Criteria<TItem>
{
    private Criteria<TItem> _criteria1;
    private Criteria<TItem> _criteria2;

    public Alternative(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        _criteria1 = criteria1;
        _criteria2 = criteria2;
    }

    public bool IsSatisfiedBy(TItem item)
    {
        return _criteria2.IsSatisfiedBy(item) || _criteria1.IsSatisfiedBy(item);
    }
}

class Where<TItem>
{

    public static CriteriaBuilder<TItem, TProperty> HasAn<TProperty>(Func<Pet,Species> propertySelector)
    {
        return new CriteriaBuilder<TItem,TProperty>(propertySelector);
    }

    internal class CriteriaBuilder<TItem, TProperty>
    {
        private Func<Pet, Species> _propertySelector;
        public CriteriaBuilder(Func<Pet, Species> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        public Criteria<TItem> EqualTo(TProperty species)
        {
            return null;
        }
    }
}



public static class CriteriaExtensions
{

    public static Criteria<TItem> And<TItem>(this Criteria<TItem> c1, Criteria<TItem> c2)
    {
        return new Conjunction<TItem>(c1, c2);
    }

    public static Criteria<TItem> Or<TItem>(this Criteria<TItem> c1, Criteria<TItem> c2)
    {
        return new Alternative<TItem>(c1, c2);
    }
}

