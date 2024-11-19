using Training.DomainClasses.Criteria;

namespace Training.DomainClasses;

public static class CriteriaExtension
{
    public static Criteria<TItem> And<TItem>(this Criteria<TItem> criteria, Criteria<TItem> secondCriteria)
    {
        return new Conjuction<TItem>(criteria, secondCriteria);   
    }

    public static Criteria<TItem> Or<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
    {
        return new Alternative<TItem>(criteria1, criteria2);
    }

    public static Negation<Pet> Negate(this Criteria<Pet> criteria)
    {
        return new Negation<Pet>(criteria);
    }
}