using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses;

public class ReadOnlySet<TItem> : IEnumerable<TItem>
{
    public ReadOnlySet(IEnumerable<TItem> items)
    {
        _items = items;
    }

    private IEnumerable<TItem> _items;

    public IEnumerator<TItem> GetEnumerator()
    {

        foreach (var item in _items)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}