namespace Training.DomainClasses;

public abstract class BinaryCriteria<T>(ICriteria<T> criteria1, ICriteria<T> criteria2) : ICriteria<T>
{
    public abstract bool IsSatisfiedBy(T item);
     
}