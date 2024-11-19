namespace Training.DomainClasses;

public class Negate<TItem>(ICriteria<TItem> criteria) : ICriteria<TItem>
{
    public bool IsSatisfiedBy(TItem item)
    {
        return !criteria.IsSatisfiedBy(item);
    }
}