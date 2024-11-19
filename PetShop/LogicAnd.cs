namespace Training.DomainClasses;

public class LogicAnd<T>(ICriteria<T> criteria1, ICriteria<T> criteria2) : BinaryCriteria<T>(criteria1, criteria2)
{
    public override bool IsSatisfiedBy(T item)
    {
        return criteria1.IsSatisfiedBy(item) && criteria2.IsSatisfiedBy(item);
    }
}