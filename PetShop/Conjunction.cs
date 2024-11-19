namespace Training.DomainClasses;

public class Conjunction<T>(Criteria<T> first, Criteria<T> second) : Criteria<T>
{
    public bool IsSatisfiedBy(T item)
    {
        return first.IsSatisfiedBy(item) && second.IsSatisfiedBy(item);
    }
}