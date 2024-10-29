using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses;

public class ReadOnlySet<TItem> : IEnumerable<TItem>
{
    private readonly IEnumerable<TItem> _items;

    public ReadOnlySet(IEnumerable<TItem> items)
    {
        this._items = items;
    }

    public IEnumerator<TItem> GetEnumerator()
    {
        foreach (var item in this._items)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}