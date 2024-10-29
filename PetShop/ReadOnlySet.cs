using System.Collections;
using System.Collections.Generic;

namespace PetShop;

public class ReadOnlySet<T>(IList<T> items) : IEnumerable<T>
{
    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
