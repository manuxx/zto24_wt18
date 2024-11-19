using Training.DomainClasses;

public static class CriteriaExtensions
{
    public static ICriteria<TItem> And<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
    {
        return new LogicAnd<TItem>(criteria1, criteria2);
    }
    
    public static ICriteria<TItem> Or<TItem>(this ICriteria<TItem> criteria1, ICriteria<TItem> criteria2)
    {
        return new LogicOr<TItem>(criteria1, criteria2);
    }
    public static ICriteria<TItem> Not<TItem>(this ICriteria<TItem> criteria)
    {
        return new Negate<TItem>(criteria);
    }
}