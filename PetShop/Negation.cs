namespace Training.DomainClasses;

public class Negation<T>(Criteria<T> criteria) : Criteria<T>
{

    public bool IsSatisfiedBy(T item)
    {
        return !criteria.IsSatisfiedBy(item);
    }
}