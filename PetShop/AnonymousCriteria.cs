using System;

public class AnonymousCriteria<TItem> : Criteria<TItem>
{
    private readonly Predicate<TItem> _condition;

    public AnonymousCriteria(Predicate<TItem> condition)
    {
        _condition = condition;
    }

    public bool IsSatisfiedBy(TItem pet)
    {
        return _condition(pet);
    }
}