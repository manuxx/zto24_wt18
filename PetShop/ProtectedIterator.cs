using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses;

public class ProtectedIterator<TItem> : IEnumerable<TItem>
{
    private IEnumerable<TItem> _enumerable;

    public ProtectedIterator(IEnumerable<TItem> enumerable)
    {
        this._enumerable = enumerable;
    }

    public IEnumerator<TItem> GetEnumerator()
    {
        return _enumerable.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}