using System;
using Training.DomainClasses;

public static class CriteriaExtensions
{
    public static Conjunction<Pet> And(this Criteria<Pet> criteria1, Criteria<Pet> criteria2)
    {
        return new Conjunction<Pet>(criteria1, criteria2);
    }

    public static Alternative<Pet> Or(this Criteria<Pet> criteria1, Criteria<Pet> criteria2)
    {
        return new Alternative<Pet>(criteria1,criteria2);
    }
}

public class Where<TItem>
{
    public static CriteriaBuilder<TItem,TProperty> HasAn<TProperty>(Func<TItem, TProperty> propertySelector) => new CriteriaBuilder<TItem,TProperty>(propertySelector);
}

public class CriteriaBuilder<TItem,TProperty>
{
    private readonly Func<TItem, TProperty> _propertySelector;

    public CriteriaBuilder(Func<TItem, TProperty> propertySelector)
    {
        _propertySelector = propertySelector;
    }

    public Criteria<TItem> EqualTo(TProperty item) => new AnonymousCriteria<TItem>(localItem => _propertySelector(localItem).Equals(item));
}